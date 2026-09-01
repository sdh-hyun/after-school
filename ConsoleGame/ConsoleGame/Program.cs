class Program
{
    static void Main()
    {
        BattleGame game = new();

        game.Init();
        game.Render();

        while (game.IsRunning)
        {
            game.Update();
            game.Render();
        }

        game.Release();
    }
}
