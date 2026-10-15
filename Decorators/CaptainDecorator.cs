
using FootballClubManager.Players;

namespace FootballClubManager.Decorators;

public sealed class CaptainDecorator : PlayerDecorator
{
    public CaptainDecorator(Player player)
        : base(player)
    {
        Defense += 5;
        Intellect += 5;
    }

    public override void Act()
    {
        BasePlayer.Act();
        Console.WriteLine(
            $"{Name} rallies the team and leads by example!");
    }

    public override void Speak()
    {
        BasePlayer.Speak();
        Console.WriteLine($"{Name}: Stay focused. We win together!");
    }

    public override void PrintDetails()
    {
        BasePlayer.PrintDetails();
        Console.WriteLine("Specialization: Captain");
        Console.WriteLine("Bonus: +5 Defense, +5 Intellect");
    }
}
