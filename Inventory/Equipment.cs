
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
