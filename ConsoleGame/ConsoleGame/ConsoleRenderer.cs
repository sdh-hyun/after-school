using System.Text;

class GameRenderData
{
    public string PlayerName { get; }
    public int PlayerHp { get; }
    public int PlayerMaxHp { get; }
    public int PlayerItemCount { get; }
    public string MonsterName { get; }
    public int MonsterHp { get; }
    public int MonsterMaxHp { get; }
    public bool IsRunning { get; }

    public GameRenderData(
        string playerName,
        int playerHp,
        int playerMaxHp,
        int playerItemCount,
        string monsterName,
        int monsterHp,
        int monsterMaxHp,
        bool isRunning)
    {
        PlayerName = playerName;
        PlayerHp = playerHp;
        PlayerMaxHp = playerMaxHp;
        PlayerItemCount = playerItemCount;
        MonsterName = monsterName;
        MonsterHp = monsterHp;
        MonsterMaxHp = monsterMaxHp;
        IsRunning = isRunning;
    }
}

class ConsoleRenderer
{
    readonly List<string> messages = new();

    public void BeginFrame()
    {
        messages.Clear();
    }

    public void AddMessage(string message)
    {
        messages.Add(message);
    }

    public void Render(GameRenderData data)
    {
        StringBuilder screen = new();
        screen.AppendLine("=== 턴제 콘솔 전투 ===");

        foreach (string message in messages)
        {
            screen.AppendLine(message);
        }

        screen.AppendLine();
        screen.AppendLine($"{data.PlayerName}: {data.PlayerHp}/{data.PlayerMaxHp}  물약: {data.PlayerItemCount}개");
        screen.AppendLine($"{data.MonsterName}: {data.MonsterHp}/{data.MonsterMaxHp}");

        if (data.IsRunning)
        {
            screen.Append("1. 공격  2. 회복  3. 방어  0. 종료: ");
        }

        Console.Clear();
        Console.Write(screen.ToString());
    }

    public void Release()
    {
        messages.Clear();
    }
}
