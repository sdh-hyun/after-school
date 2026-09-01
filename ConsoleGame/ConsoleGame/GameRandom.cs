static class GameRandom
{
    static readonly Random random = new();

    public static int Range(int minValue, int maxValue)
    {
        return random.Next(minValue, maxValue);
    }
}
