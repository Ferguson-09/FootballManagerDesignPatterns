
using FootballClubManager.Players;

namespace FootballClubManager.Decorators;

public sealed class FinisherDecorator : PlayerDecorator
{
    public FinisherDecorator(Player player)
        : base(player)
    {
        Strength += 10;
        Agility += 5;
    }

    public override void Act()
    {
        BasePlayer.Act();
        Console.WriteLine(
            $"{Name} uses the Finisher skill to take a powerful, accurate shot!");
    }

    public override void Speak()
    {
        BasePlayer.Speak();
        Console.WriteLine($"{Name}: Give me one chance and I'll score!");
    }

    public override void PrintDetails()
    {
        BasePlayer.PrintDetails();
        Console.WriteLine("Specialization: Finisher");
        Console.WriteLine("Bonus: +10 Strength, +5 Agility");
    }
}
