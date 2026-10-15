
namespace FootballClubManager.Players;

public class Goalkeeper : Player
{
    public Goalkeeper(string name)
        : base(name, 110, 95, 55, 75, 80, 90)
    {
    }

    public override void Act()
    {
        Console.WriteLine($"{Name} watches the shot and dives to make a save!");
    }
}
