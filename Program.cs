
using FootballClubManager.Factories;
using FootballClubManager.Players;

Console.WriteLine("=== Football Club Manager ===");
Console.WriteLine("Player Creation Test\n");

Console.Write("Enter player name: ");
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
    Console.WriteLine("Invalid selection.");
    return;
}

PlayerFactory factory = PlayerFactoryProvider.GetFactory(position);
Player player = factory.CreatePlayer(name);

Console.WriteLine("\nPlayer created successfully!");
player.PrintDetails();
player.Act();
player.Speak();


// internal class Program
// {
//     private static void Main(string[] args)
//     {
        
//     }
// }