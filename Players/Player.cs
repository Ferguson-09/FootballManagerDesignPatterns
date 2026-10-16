
namespace FootballClubManager.Players;
using FootballClubManager.Inventory;

public abstract class Player
{
    public string Name { get; }
    public virtual string PositionName => GetType().Name;    public int Health { get; protected set; }
    public int Defense { get; protected set; }
    public int Speed { get; protected set; }
    public int Strength { get; protected set; }
    public int Intellect { get; protected set; }
    public int Agility { get; protected set; }
    public List<Equipment> EquippedItems { get; } = new();

    protected Player(
        string name,
        int health,
        int defense,
        int speed,
        int strength,
        int intellect,
        int agility)
    {
        Name = name;
        Health = health;
        Defense = defense;
        Speed = speed;
        Strength = strength;
        Intellect = intellect;
        Agility = agility;
    }

    public abstract void Act();

    public virtual void Speak()
    {
        Console.WriteLine($"{Name}: Ready to play!");
    }

    
    
    public virtual void PrintDetails()
    {
        int equipmentStrength = EquippedItems.Sum(item => item.StrengthBonus);
        int equipmentDefense = EquippedItems.Sum(item => item.DefenseBonus);

        Console.WriteLine($"\n--- {Name} ---");
        Console.WriteLine($"Position: {PositionName}");
        Console.WriteLine($"Health: {Health}");
        Console.WriteLine($"Defense: {Defense + equipmentDefense}");
        Console.WriteLine($"Speed: {Speed}");
        Console.WriteLine($"Strength: {Strength + equipmentStrength}");
        Console.WriteLine($"Intellect: {Intellect}");
        Console.WriteLine($"Agility: {Agility}");

        Console.WriteLine("Equipped equipment:");

        if (EquippedItems.Count == 0)
        {
            Console.WriteLine("None");
        }
        else
        {
            foreach (Equipment item in EquippedItems)
            {
                Console.WriteLine($"- {item.Name}");
            }
        }
    }

}
