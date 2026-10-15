
using FootballClubManager.Players;

namespace FootballClubManager.Factories;

// The Creator defines the factory method.
public abstract class PlayerFactory
{
    public abstract Player CreatePlayer(string name);
}

// Each concrete factory creates a specific player type.
public sealed class StrikerFactory : PlayerFactory
{
    public override Player CreatePlayer(string name)
    {
        return new Striker(name);
    }
}

public sealed class MidfielderFactory : PlayerFactory
{
    public override Player CreatePlayer(string name)
    {
        return new Midfielder(name);
    }
}

public sealed class DefenderFactory : PlayerFactory
{
    public override Player CreatePlayer(string name)
    {
        return new Defender(name);
    }
}

public sealed class GoalkeeperFactory : PlayerFactory
{
    public override Player CreatePlayer(string name)
    {
        return new Goalkeeper(name);
    }
}
