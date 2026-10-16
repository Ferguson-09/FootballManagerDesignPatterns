
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
        if (salePrice < 0)
        {
            Console.WriteLine("Sale price cannot be negative.");
            return false;
        }

        if (!_inventoryService.Remove(equipmentName))
        {
            Console.WriteLine("Equipment not found.");
            return false;
        }

        // The current GameWorld API only supports spending funds.
        // We'll add a safe deposit method in the next integration step.
        Console.WriteLine(
            $"Removed {equipmentName} from inventory. " +
            $"Sale proceeds of ${salePrice:N2} are not yet credited.");
        return true;
    }

    public void ShowInventory()
    {
        _inventoryService.PrintInventory();
    }
}
