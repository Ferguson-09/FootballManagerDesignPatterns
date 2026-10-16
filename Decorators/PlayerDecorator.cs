
using FootballClubManager.Players;

namespace FootballClubManager.Decorators;

public abstract class PlayerDecorator : Player
{
    protected Player BasePlayer { get; }

    public override string PositionName => BasePlayer.PositionName;

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

    // Print this decorator's stats, which include its bonuses.
    public override void PrintDetails()
    {
        base.PrintDetails();
    }
}
