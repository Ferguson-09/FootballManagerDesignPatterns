
namespace FootballClubManager.Factories;

public static class PlayerFactoryProvider
{
    public static PlayerFactory GetFactory(string position)
    {
        return position.Trim().ToLowerInvariant() switch
        {
            "striker" => new StrikerFactory(),
            "midfielder" => new MidfielderFactory(),
            "defender" => new DefenderFactory(),
            "goalkeeper" => new GoalkeeperFactory(),
            _ => throw new ArgumentException(
                "Unknown player position.",
                nameof(position))
        };
    }
}
