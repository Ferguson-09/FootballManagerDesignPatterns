
using FootballClubManager.Decorators;
using FootballClubManager.Factories;
using FootballClubManager.Inventory;
using FootballClubManager.Players;

namespace FootballClubManager.Core;

public sealed class GameController
{
    private readonly GameWorld _world = GameWorld.Instance;
    private readonly InventoryFacade _inventory = new();

    public void Run()
    {
        bool running = true;

        Console.WriteLine("================================");
        Console.WriteLine("     FOOTBALL CLUB MANAGER");
        Console.WriteLine("================================");

        while (running)
        {
            PrintMenu();

            Console.Write("Choose an option: ");
            string? choice = Console.ReadLine();

            Console.WriteLine();

            switch (choice)
            {
                case "1":
                    RecruitPlayer();
                    break;
                case "2":
                    ViewSquad();
                    break;
                case "3":
                    SpecializePlayer();
                    break;
                case "4":
                    ManageInventory();
                    break;
                case "5":
                    SimulateMatch();
                    break;
                case "6":
                    _world.PrintStatus();
                    break;
                case "0":
                    running = false;
                    Console.WriteLine("Thanks for managing your club!");
                    break;
                default:
                    Console.WriteLine("Invalid option. Try again.");
                    break;
            }

            if (running)
            {
                Console.WriteLine("\nPress Enter to return to the menu...");
                Console.ReadLine();
            }
        }
    }

    private static void PrintMenu()
    {
        Console.WriteLine("\n========== MAIN MENU ==========");
        Console.WriteLine("1. Recruit a player");
        Console.WriteLine("2. View squad");
        Console.WriteLine("3. Specialize a player");
        Console.WriteLine("4. Manage inventory");
        Console.WriteLine("5. Simulate match");
        Console.WriteLine("6. View club status");
        Console.WriteLine("0. Exit");
        Console.WriteLine("===============================");
    }

    private void RecruitPlayer()
    {
        Console.Write("Enter the player's name: ");
        string name = Console.ReadLine()?.Trim() ?? "";

        if (string.IsNullOrWhiteSpace(name))
        {
            Console.WriteLine("Player name cannot be empty.");
            return;
        }

        Console.WriteLine("\nChoose a position:");
        Console.WriteLine("1. Striker");
        Console.WriteLine("2. Midfielder");
        Console.WriteLine("3. Defender");
        Console.WriteLine("4. Goalkeeper");
        Console.Write("Selection: ");

        string? choice = Console.ReadLine();

        string? position = choice switch
        {
            "1" => "striker",
            "2" => "midfielder",
            "3" => "defender",
            "4" => "goalkeeper",
            _ => null
        };

        if (position is null)
        {
            Console.WriteLine("Invalid position.");
            return;
        }

        const decimal recruitmentCost = 5_000m;

        if (!_world.SpendFunds(recruitmentCost))
        {
            Console.WriteLine("The club cannot afford this player.");
            return;
        }

        try
        {
            PlayerFactory factory =
                PlayerFactoryProvider.GetFactory(position);

            Player player = factory.CreatePlayer(name);
            _world.AddPlayer(player);

            Console.WriteLine(
                $"{name} has joined the club for ${recruitmentCost:N2}.");
            player.PrintDetails();
        }
        catch (ArgumentException ex)
        {
            _world.AddFunds(recruitmentCost);
            Console.WriteLine($"Recruitment failed: {ex.Message}");
        }
    }

    private void ViewSquad()
    {
        if (_world.Squad.Count == 0)
        {
            Console.WriteLine("Your squad is empty. Recruit a player first.");
            return;
        }

        Console.WriteLine("========== YOUR SQUAD ==========");

        for (int i = 0; i < _world.Squad.Count; i++)
        {
            Console.WriteLine($"\nPlayer #{i + 1}");
            _world.Squad[i].PrintDetails();
        }
    }

    private void SpecializePlayer()
    {
        int index = SelectPlayer();

        if (index < 0)
        {
            return;
        }

        Player player = _world.Squad[index];

        Console.WriteLine("\nChoose a specialization:");
        Console.WriteLine("1. Finisher (+10 Strength, +5 Agility)");
        Console.WriteLine("2. Playmaker (+10 Intellect, +5 Agility)");
        Console.WriteLine("3. Captain (+5 Defense, +5 Intellect)");
        Console.Write("Selection: ");

        string? choice = Console.ReadLine();

        Player specializedPlayer = choice switch
        {
            "1" => new FinisherDecorator(player),
            "2" => new PlaymakerDecorator(player),
            "3" => new CaptainDecorator(player),
            _ => player
        };

        if (choice is not ("1" or "2" or "3"))
        {
            Console.WriteLine("Invalid specialization.");
            return;
        }

        _world.Squad[index] = specializedPlayer;

        Console.WriteLine("\nSpecialization applied!");
        specializedPlayer.PrintDetails();
    }

    private void ManageInventory()
    {
        bool back = false;

        while (!back)
        {
            Console.WriteLine("\n========== INVENTORY ==========");
            Console.WriteLine("1. Purchase equipment");
            Console.WriteLine("2. View inventory");
            Console.WriteLine("3. Sell equipment");
            Console.WriteLine("4. Equip item to a player");
            Console.WriteLine("0. Back to main menu");

            switch (Console.ReadLine())
            {
                case "1":
                    PurchaseEquipment();
                    break;
                case "2":
                    _inventory.ShowInventory();
                    break;
                case "3":
                    SellEquipment();
                    break;
                case "4":
                    EquipEquipment();
                    break;
                case "0":
                    back = true;
                    break;
                default:
                    Console.WriteLine("Invalid option.");
                    break;
            }
        }
    }

    private void PurchaseEquipment()
    {
        Console.WriteLine("\nAvailable equipment:");
        Console.WriteLine("1. Elite Boots ($2,500; +2 Strength)");
        Console.WriteLine("2. Defensive Vest ($1,000; +3 Defense)");
        Console.WriteLine("3. Training Kit ($1,500; +2 Strength, +2 Defense)");
        Console.Write("Selection: ");

        Equipment? equipment = Console.ReadLine() switch
        {
            "1" => new Equipment("Elite Boots", 2, 0, 2_500m),
            "2" => new Equipment("Defensive Vest", 0, 3, 1_000m),
            "3" => new Equipment("Training Kit", 2, 2, 1_500m),
            _ => null
        };

        if (equipment is null)
        {
            Console.WriteLine("Invalid equipment selection.");
            return;
        }

        _inventory.PurchaseEquipment(equipment);
    }

    private void SellEquipment()
    {
        Console.Write("Enter the exact equipment name to sell: ");
        string name = Console.ReadLine()?.Trim() ?? "";

        if (string.IsNullOrWhiteSpace(name))
        {
            Console.WriteLine("Equipment name cannot be empty.");
            return;
        }

        Console.Write("Enter the sale price: $");

        if (!decimal.TryParse(Console.ReadLine(), out decimal price))
        {
            Console.WriteLine("Enter a valid amount.");
            return;
        }

        _inventory.SellEquipment(name, price);
    }

    private int SelectPlayer()
    {
        if (_world.Squad.Count == 0)
        {
            Console.WriteLine("Your squad is empty. Recruit a player first.");
            return -1;
        }

        Console.WriteLine("\nSelect a player:");

        for (int i = 0; i < _world.Squad.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_world.Squad[i].Name}");
        }

        Console.Write("Player number: ");

        if (!int.TryParse(Console.ReadLine(), out int selection) ||
            selection < 1 ||
            selection > _world.Squad.Count)
        {
            Console.WriteLine("Invalid player number.");
            return -1;
        }

        return selection - 1;
    }

    private void SimulateMatch()
    {
        if (_world.Squad.Count == 0)
        {
            Console.WriteLine("Recruit at least one player before a match.");
            return;
        }

        if (_world.MatchMinute >= 90)
        {
            Console.WriteLine("The match has already reached 90 minutes.");
            return;
        }

        Console.WriteLine("Your squad takes the field!");

        foreach (Player player in _world.Squad)
        {
            player.Act();
        }

        _world.AdvanceMatchTime(15);

        Console.WriteLine(
            $"Match time: {_world.MatchMinute} minutes.");

        if (_world.MatchMinute >= 90)
        {
            Console.WriteLine("Full time!");
        }
    }

    private void EquipEquipment()
    {
        if (_world.Squad.Count == 0)
        {
            Console.WriteLine("Recruit a player first.");
            return;
        }

        _inventory.ShowInventory();

        Console.Write("Enter the exact equipment name: ");
        string name = Console.ReadLine()?.Trim() ?? "";

        if (string.IsNullOrWhiteSpace(name))
        {
            Console.WriteLine("Equipment name cannot be empty.");
            return;
        }

        int index = SelectPlayer();

        if (index < 0)
        {
            return;
        }

        _inventory.EquipItem(name, _world.Squad[index]);
    }

}
