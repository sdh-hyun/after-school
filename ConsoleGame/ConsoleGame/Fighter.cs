class Fighter
{
    public string Name { get; }
    public int Hp { get; private set; }
    public int MaxHp { get; }
    public int AttackPower { get; }
    public bool IsDead => Hp <= 0;

    public Fighter(string name, int hp, int attackPower)
    {
        Name = name;
        Hp = hp;
        MaxHp = hp;
        AttackPower = attackPower;
    }

    public int Attack(Fighter target)
    {
        int damage = GameRandom.Range(AttackPower - 2, AttackPower + 3);
        return target.TakeDamage(damage);
    }

    public virtual int TakeDamage(int damage)
    {
        int previousHp = Hp;
        Hp = Math.Max(0, Hp - damage);
        return previousHp - Hp;
    }

    public int Heal(int amount)
    {
        int previousHp = Hp;
        Hp = Math.Min(MaxHp, Hp + amount);
        return Hp - previousHp;
    }
}
