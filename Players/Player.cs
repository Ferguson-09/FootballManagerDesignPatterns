
namespace FootballClubManager.Players;

public abstract class Player
{
    public string Name { get; }
    public virtual string PositionName => GetType().Name;    public int Health { get; protected set; }
    public int Defense { get; protected set; }
    public int Speed { get; protected set; }
    public int Strength { get; protected set; }
    public int Intellect { get; protected set; }
    public int Agility { get; protected set; }

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
        Console.WriteLine($"\n--- {Name} ---");
        Console.WriteLine($"Position: {PositionName}");
        Console.WriteLine($"Health: {Health}");
        Console.WriteLine($"Defense: {Defense}");
        Console.WriteLine($"Speed: {Speed}");
        Console.WriteLine($"Strength: {Strength}");
        Console.WriteLine($"Intellect: {Intellect}");
        Console.WriteLine($"Agility: {Agility}");
    }

}
