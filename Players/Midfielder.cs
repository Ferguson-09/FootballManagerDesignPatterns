
namespace FootballClubManager.Players;

public class Midfielder : Player
{
    public Midfielder(string name)
        : base(name, 100, 60, 78, 65, 90, 80)
    {
    }

    public override void Act()
    {
        Console.WriteLine($"{Name} controls possession and creates a passing opportunity!");
    }
}
