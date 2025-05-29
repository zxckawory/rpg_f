using System.Drawing;

class Character
{
    public int Number;
    public int Health;
    protected int MaxHealth;
    protected int Damage;
    public int Lager;
    public int X;
    public int Y;

    public Character(int number, int health, int damage, int lager, int x, int y)
    {
        Number = number;
        Health = health;
        MaxHealth = health;
        Damage = damage;
        Lager = lager;
        X = x;
        Y = y;

        //Postavit();
    }

    protected virtual void Postavit()
    {
        GameField.Pole[X, Y] = Number.ToString(); 
    }

    protected void Ubrat()
    {
        GameField.Pole[X, Y] = ".";
        GameField.Color[X, Y] = ConsoleColor.DarkGreen;
    }

    public void Info()
    {
        Console.Write($"Номер персонажа: {Number}, ");
        Console.Write($"Здоровье персонажа: {Health}, ");
        Console.Write($"Урон персонажа: {Damage}, ");
        Console.Write($"Лагерь персонажа: {(Lager == 1 ? "Красный" : "Синий")}, ");
        Console.WriteLine($"Местоположение: {X}, {Y}");
    }

    public void Move(int x, int y)
    {
        if (GameField.Pole[x, y] == ".")
        {
            Ubrat();
            X = x;
            Y = y;
            Postavit();
            Console.WriteLine("Персонаж перемещен");
        }
        else Console.WriteLine("Места нет");
    }

    public void Attack(List<Character> enemies)
    {
        int damage = Damage / enemies.Count;
        foreach (Character character in enemies)
        {
            Console.WriteLine($"Персонаж {Number} {(Lager == 1 ? "Красный" : "Синий")} атаковал {character.Number} {(character.Lager == 1 ? "Красный" : "Синий")} с уроном {damage}");
            character.Health -= damage;

            if (character.Health <= 0)
            {
                character.Health = 0;
                Console.WriteLine($"Персонаж {character.Number} {(character.Lager == 1 ? "Красный" : "Синий")} умер");
                Ubrat();
            }
        }
    }

    public void Lechenie(int health)
    {
        Health += health;
        Console.WriteLine("Персонаж полечился");
    }

    public void MaxHealthCheck()
    {
        if (MaxHealth == Health)
        {
            Console.WriteLine("У персонажа максимальное здоровье");
        }
        else
        {
            bool isCorrect;
            int value;
            do
            {
                Console.Write("Введите количество здоровья: ");
                isCorrect = int.TryParse(Console.ReadLine(), out value);
                if (!isCorrect || value <= 0)
                {
                    Console.WriteLine("Некорректный ввод");
                    continue;
                }
                if (Health + value > MaxHealth)
                {
                    Console.WriteLine("Слишком много здоровья.");
                    continue;
                }
                break;
            } while (true);

            Lechenie(value);
        }
    }
}