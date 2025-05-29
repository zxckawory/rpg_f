class GameField
{
    public static int Width = 10;
    public static int Height = 10;
    public static string[,] Pole = new string[Width, Height];
    public static ConsoleColor[,] Color = new ConsoleColor[Width, Height];

    static public void DrawPole()
    {
        Console.WriteLine("  X 0 1 2 3 4 5 6 7 8 9");
        Console.WriteLine("Y _____________________");
        for (int i = 0; i < Width; i++)
        {
            for (int j = 0; j < Height; j++)
            {
                if (j == 0)
                {
                    Console.Write($"{i} | ");
                }
                Console.ForegroundColor = Color[j, i];
                Console.Write(Pole[j, i] + " ");
                Console.ResetColor();
            }
            Console.WriteLine();
        }
        Console.WriteLine();
    }
}