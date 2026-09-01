abstract class Item
{
    public string Name { get; }

    protected Item(string name)
    {
        Name = name;
    }

    public abstract int Use(Player player);
}

class Potion : Item
{
    readonly int healAmount;

    public Potion(int healAmount) : base("Potion")
    {
        this.healAmount = healAmount;
    }

    public override int Use(Player player)
    {
        return player.Heal(healAmount);
    }
}
