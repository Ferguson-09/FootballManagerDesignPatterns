
using FootballClubManager.Players;

namespace FootballClubManager.Decorators;

public abstract class PlayerDecorator : Player
{
    protected Player BasePlayer { get; }

    protected PlayerDecorator(Player player)
        : base(
            player.Name,
            player.Health,
            player.Defense,
            player.Speed,
            player.Strength,
            player.Intellect,
            player.Agility)
    {
        BasePlayer = player;
    }

    public override void Act()
    {
        BasePlayer.Act();
    }

    public override void Speak()
    {
        BasePlayer.Speak();
    }

    public override void PrintDetails()
    {
        BasePlayer.PrintDetails();
    }
}
