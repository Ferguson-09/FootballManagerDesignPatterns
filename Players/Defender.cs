
namespace FootballClubManager.Players;

public class Defender : Player
{
    public Defender(string name)
        : base(name, 110, 90, 65, 88, 70, 60)
    {
    }

    public override void Act()
    {
        Console.WriteLine($"{Name} tracks the attacker and makes a defensive tackle!");
    }
}
