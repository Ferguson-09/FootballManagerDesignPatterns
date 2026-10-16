
using FootballClubManager.Core;

namespace FootballClubManager.Inventory;

public sealed class InventoryFacade
{
    private readonly InventoryService _inventoryService;

    public InventoryFacade()
    {
        _inventoryService = new InventoryService();
    }

    public bool PurchaseEquipment(Equipment equipment)
    {
        GameWorld world = GameWorld.Instance;

        if (world.ClubFunds < equipment.Price)
        {
            Console.WriteLine("The club cannot afford this equipment.");
            return false;
        }

        if (!world.SpendFunds(equipment.Price))
        {
            Console.WriteLine("Purchase failed.");
            return false;
        }

        _inventoryService.Add(equipment);

        Console.WriteLine($"Purchased: {equipment.Name}");
        return true;
    }

    
    public bool SellEquipment(string equipmentName, decimal salePrice)
    {
        if (salePrice <= 0)
        {
            Console.WriteLine("Sale price must be greater than zero.");
            return false;
        }

        GameWorld world = GameWorld.Instance;

        // Confirm the equipment exists before changing club funds.
        if (!_inventoryService.Items.Any(item =>
            item.Name.Equals(
                equipmentName,
                StringComparison.OrdinalIgnoreCase)))
        {
            Console.WriteLine("Equipment not found.");
            return false;
        }

        if (!_inventoryService.Remove(equipmentName))
        {
            Console.WriteLine("Sale failed.");
            return false;
        }

        world.AddFunds(salePrice);

        Console.WriteLine(
            $"Sold {equipmentName} for ${salePrice:N2}.");

        return true;
    }


    public void ShowInventory()
    {
        _inventoryService.PrintInventory();
    }

    public bool EquipItem(
        string equipmentName,
        FootballClubManager.Players.Player player)
        {
            ArgumentNullException.ThrowIfNull(player);

            Equipment? equipment = _inventoryService.Find(equipmentName);

            if (equipment is null)
            {
                Console.WriteLine("Equipment not found in club inventory.");
                return false;
            }

            if (player.EquippedItems.Any(item =>
                item.Name.Equals(
                    equipment.Name,
                    StringComparison.OrdinalIgnoreCase)))
            {
                Console.WriteLine("This player already has that equipment.");
                return false;
            }

            player.EquippedItems.Add(equipment);
            _inventoryService.Remove(equipment.Name);

            Console.WriteLine($"{equipment.Name} equipped by {player.Name}.");
            return true;
    }

}
