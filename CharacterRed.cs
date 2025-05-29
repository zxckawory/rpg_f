using System.Reflection.Emit;

class CharacterRed : Character
{
    public CharacterRed(int number, int health, int damage, int x, int y) : base(number, health, damage, 1, x, y)
    {
        Number = number;
        Health = health;
        Damage = damage;
        Lager = 1;
        X = x;
        Y = y;
        Postavit();
    }

    protected override void Postavit()
    {
        GameField.Color[X, Y] = ConsoleColor.Red;
        GameField.Pole[X, Y] = Number.ToString();
    }
}