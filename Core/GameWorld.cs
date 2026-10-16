
using FootballClubManager.Players;

namespace FootballClubManager.Core;

public sealed class GameWorld
{
    private static readonly Lazy<GameWorld> _instance =
        new(() => new GameWorld());

    public static GameWorld Instance => _instance.Value;

    public decimal ClubFunds { get; private set; } = 100_000m;

    public int MatchMinute { get; private set; }

    public List<Player> Squad { get; } = new();

    private GameWorld()
    {
    }

    public void AddPlayer(Player player)
    {
        ArgumentNullException.ThrowIfNull(player);
        Squad.Add(player);
    }

    public bool SpendFunds(decimal amount)
    {
        if (amount <= 0 || amount > ClubFunds)
        {
            return false;
        }

        ClubFunds -= amount;
        return true;
    }

    public bool AddFunds(decimal amount)
    {
        if (amount <= 0)
        {
            return false;
        }

        ClubFunds += amount;
        return true;
    }

    public void AdvanceMatchTime(int minutes)
    {
        if (minutes <= 0)
        {
            return;
        }

        MatchMinute = Math.Min(90, MatchMinute + minutes);
    }

    public void PrintStatus()
    {
        Console.WriteLine("\n=== Club Status ===");
        Console.WriteLine($"Club funds: ${ClubFunds:N2}");
        Console.WriteLine($"Match minute: {MatchMinute}");
        Console.WriteLine($"Squad size: {Squad.Count}");
    }
}
