class BattleGame
{
    readonly ConsoleRenderer renderer = new();

    Player player = new("Player", 30, 8);
    Fighter monster = new("Slime", 25, 6);

    public bool IsRunning { get; private set; }

    public void Init()
    {
        player = new Player("Player", 30, 8);
        monster = new Fighter("Slime", 25, 6);
        player.AddItem(new Potion(10));

        renderer.BeginFrame();
        renderer.AddMessage("전투를 시작합니다.");
        IsRunning = true;
    }

    public void Update()
    {
        if (!IsRunning)
        {
            return;
        }

        renderer.BeginFrame();
        Player.Action action = ReadAction();

        if (action == Player.Action.Quit)
        {
            renderer.AddMessage("게임을 종료합니다.");
            IsRunning = false;
            return;
        }

        if (!PlayPlayerTurn(action))
        {
            return;
        }

        PlayMonsterTurn();
        CheckGameOver();
    }

    public void Render()
    {
        GameRenderData renderData = new(
            player.Name,
            player.Hp,
            player.MaxHp,
            player.ItemCount,
            monster.Name,
            monster.Hp,
            monster.MaxHp,
            IsRunning);

        renderer.Render(renderData);
    }

    public void Release()
    {
        IsRunning = false;
        renderer.Release();
    }

    Player.Action ReadAction()
    {
        string? input = Console.ReadLine();

        return input switch
        {
            "1" => Player.Action.Attack,
            "2" => Player.Action.Potion,
            "3" => Player.Action.Defend,
            "0" or null => Player.Action.Quit,
            _ => Player.Action.Invalid
        };
    }

    bool PlayPlayerTurn(Player.Action action)
    {
        if (action == Player.Action.Attack)
        {
            int damage = player.Attack(monster);
            renderer.AddMessage($"{player.Name}의 공격! {monster.Name}에게 {damage} 피해");
            return true;
        }

        if (action == Player.Action.Potion)
        {
            bool used = player.UsePotion(out int healedHp);
            if (!used)
            {
                renderer.AddMessage("사용할 수 있는 물약이 없습니다.");
                return false;
            }

            renderer.AddMessage($"물약을 사용해 체력을 {healedHp} 회복했습니다.");
            return true;
        }

        if (action == Player.Action.Defend)
        {
            player.Defend();
            renderer.AddMessage("방어 자세를 취했습니다. 이번 턴에 받는 피해가 절반으로 감소합니다.");
            return true;
        }

        renderer.AddMessage("올바른 행동을 입력하세요.");
        return false;
    }

    void PlayMonsterTurn()
    {
        if (monster.IsDead)
        {
            return;
        }

        int damage = monster.Attack(player);
        renderer.AddMessage($"{monster.Name}의 반격! {player.Name}에게 {damage} 피해");
    }

    void CheckGameOver()
    {
        if (!player.IsDead && !monster.IsDead)
        {
            return;
        }

        renderer.AddMessage(monster.IsDead ? "승리!" : "게임 오버");
        IsRunning = false;
    }
}
