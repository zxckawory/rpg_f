class GameField
{
    public static int Width = 11;
    public static int Height = 11;
    public static string[,] Pole = new string[Width,Height];

    static public void DrawPole()
    {
        Console.WriteLine("  X 0 1 2 3 4 5 6 7 8 9");
        Console.WriteLine("Y _____________________");
        for (int i = 0; i < Width - 1; i++)
        {
            for (int j = 0; j < Height - 1; j++)
            {
                if (j == 0)
                {
                    Console.Write($"{i} | ");
                }
                Console.Write(Pole[j,i] + " ");
            }
            Console.WriteLine();
        }
        Console.WriteLine();
    }
}