
namespace FootballClubManager.Inventory;

public sealed class InventoryService
{
    private readonly List<Equipment> _items = new();

    public IReadOnlyList<Equipment> Items => _items;

    public void Add(Equipment equipment)
    {
        _items.Add(equipment);
    }

    public Equipment? Find(string equipmentName)
    {
        return _items.FirstOrDefault(item =>
            item.Name.Equals(
                equipmentName,
                StringComparison.OrdinalIgnoreCase));
    }

    public bool Remove(string equipmentName)
    {
        Equipment? item = Find(equipmentName);

        if (item is null)
        {
            return false;
        }

        _items.Remove(item);
        return true;
    }

    public void PrintInventory()
    {
        Console.WriteLine("\n=== Club Inventory ===");

        if (_items.Count == 0)
        {
            Console.WriteLine("The inventory is empty.");
            return;
        }

        for (int i = 0; i < _items.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_items[i]}");
        }
    }
}
