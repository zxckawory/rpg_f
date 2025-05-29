class CharacterBlue : Character
{
    public CharacterBlue(int number, int health, int damage, int x, int y) : base(number, health, damage, 2, x, y)
    {
        Number = number;
        Health = health;
        Damage = damage;
        Lager = 2;
        X = x;
        Y = y;
        Postavit();
    }

    protected override void Postavit()
    {
        GameField.Color[X, Y] = ConsoleColor.Blue;
        GameField.Pole[X, Y] = Number.ToString();
    }
}