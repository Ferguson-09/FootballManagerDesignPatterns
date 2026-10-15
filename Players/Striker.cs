
namespace FootballClubManager.Players;

public class Striker : Player
{
    public Striker(string name)
        : base(name, 100, 45, 90, 85, 65, 88)
    {
    }

    public override void Act()
    {
        Console.WriteLine($"{Name} makes a forward run and shoots at goal!");
    }
}
