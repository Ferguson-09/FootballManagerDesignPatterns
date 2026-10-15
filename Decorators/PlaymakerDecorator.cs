
using FootballClubManager.Players;

namespace FootballClubManager.Decorators;

public sealed class PlaymakerDecorator : PlayerDecorator
{
    public PlaymakerDecorator(Player player)
        : base(player)
    {
        Intellect += 10;
        Agility += 5;
    }

    public override void Act()
    {
        BasePlayer.Act();
        Console.WriteLine(
            $"{Name} uses Playmaker vision to create a scoring opportunity!");
    }

    public override void Speak()
    {
        BasePlayer.Speak();
        Console.WriteLine($"{Name}: Make the run; I'll find you!");
    }

    public override void PrintDetails()
    {
        BasePlayer.PrintDetails();
        Console.WriteLine("Specialization: Playmaker");
        Console.WriteLine("Bonus: +10 Intellect, +5 Agility");
    }
}
