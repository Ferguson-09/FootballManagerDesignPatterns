
namespace FootballClubManager.Inventory;

public sealed class Equipment
{
    public string Name { get; }
    public int StrengthBonus { get; }
    public int DefenseBonus { get; }
    public decimal Price { get; }

    public Equipment(
        string name,
        int strengthBonus,
        int defenseBonus,
        decimal price)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException(
                "Equipment must have a name.", nameof(name));
        }

        if (strengthBonus < 0 || defenseBonus < 0 || price <= 0)
        {
            throw new ArgumentOutOfRangeException(
                nameof(price),
                "Bonuses cannot be negative and price must be positive.");
        }

        Name = name;
        StrengthBonus = strengthBonus;
        DefenseBonus = defenseBonus;
        Price = price;
    }

    public override string ToString()
    {
        return $"{Name} | Strength +{StrengthBonus} | " +
               $"Defense +{DefenseBonus} | ${Price:N2}";
    }
}
