class Player : Fighter
{
    public enum Action
    {
        Attack,
        Potion,
        Defend,
        Quit,
        Invalid
    }

    readonly List<Item> items = new();
    bool isDefending;

    public int ItemCount => items.Count;

    public Player(string name, int hp, int attackPower) : base(name, hp, attackPower)
    {
    }

    public void AddItem(Item item)
    {
        items.Add(item);
    }

    public bool UsePotion(out int healedHp)
    {
        Item? potion = items.Find(item => item is Potion);
        if (potion == null)
        {
            healedHp = 0;
            return false;
        }

        healedHp = potion.Use(this);
        items.Remove(potion);
        return true;
    }

    public void Defend()
    {
        isDefending = true;
    }

    public override int TakeDamage(int damage)
    {
        if (isDefending)
        {
            damage = (int)Math.Ceiling(damage / 2.0);
            isDefending = false;
        }

        return base.TakeDamage(damage);
    }
}
