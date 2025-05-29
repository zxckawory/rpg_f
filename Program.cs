class Program
{
    public static List<CharacterRed> RedLager = [];
    public static List<CharacterBlue> BlueLager = [];
    static void Main()
    {
        for (int i = 0; i < GameField.Width; i++)
        {
            for (int j = 0; j < GameField.Height; j++)
            {
                GameField.Pole[i, j] = ".";
                GameField.Color[i, j] = ConsoleColor.DarkGreen;
            }
        }

        RedLager.Add(new CharacterRed(0, 100, 10, 0, 1));
        RedLager.Add(new CharacterRed(1, 100, 10, 0, 2));
        BlueLager.Add(new CharacterBlue(0, 100, 10, 1, 1));
        BlueLager.Add(new CharacterBlue(1, 100, 10, 1, 2));

        while (true)
        {
            Console.WriteLine();
            GameField.DrawPole();
            Console.WriteLine("Меню: ");
            Console.WriteLine("1. Добавить персонажа");
            Console.WriteLine("2. Выбрать персонажа");
            Console.WriteLine("3. Вывод всех персонажей");
            Console.WriteLine("4. Выход");

            int choice = CorrectInt("Выберите пункт меню: ", 1, 4);
            Console.WriteLine();

            switch (choice)
            {
                case 1:
                    {
                        NewCharacter();
                        break;
                    }
                case 2:
                    {
                        Character personaj;
                        int vibor = CorrectInt("Выберите лагерь(1 - красный, 2 - синий): ", 1, 2);
                        Console.WriteLine();
                        if (vibor == 1)
                        {
                            foreach (Character guzlic in RedLager)
                            {
                                guzlic.Info();
                            }
                            Console.WriteLine();
                            while (true)
                            {
                                int index = CorrectInt("Выберите персонажа: ", 0, RedLager.Count - 1);
                                if (RedLager[index].Health > 0)
                                {
                                    personaj = RedLager[index];
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("Этот персонаж мёртв. Выберите другого.");
                                }
                            }
                        }
                        else
                        {
                            foreach (Character guzlyach in BlueLager)
                            {
                                guzlyach.Info();
                            }
                            Console.WriteLine();
                            while (true)
                            {
                                int index = CorrectInt("Выберите персонажа: ", 0, BlueLager.Count - 1);
                                if (BlueLager[index].Health > 0)
                                {
                                    personaj = BlueLager[index];
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("Этот персонаж мёртв. Выберите другого.");
                                }
                            }
                        }

                        while (true)
                        {
                            Console.WriteLine();
                            GameField.DrawPole();
                            personaj.Info();
                            Console.WriteLine();
                            Console.WriteLine("Действия персонажа: ");
                            Console.WriteLine("1. Передвижение");
                            Console.WriteLine("2. Атака");
                            Console.WriteLine("3. Лечение");
                            Console.WriteLine("4. Выход");
                            choice = CorrectInt("Выберите действие персонажа: ", 1, 4);
                            if (choice == 4)
                                break;
                            Console.WriteLine();

                            switch (choice)
                            {
                                case 1:
                                    {
                                        int x = CorrectInt("Введите координату по горизонтали: ", 0, 9);
                                        int y = CorrectInt("Введите координату по вертикали: ", 0, 9);
                                        Console.WriteLine();
                                        personaj.Move(x, y);
                                        break;
                                    }
                                case 2:
                                    {
                                        List<Character> list = FindEnemy(personaj);
                                        if (list.Count == 0)
                                        {
                                            Console.WriteLine("Врягов рядом нет");
                                            break;
                                        }

                                        int x = CorrectInt("Введите координату врага по горизонтали: ", 0, 9);
                                        int y = CorrectInt("Введите координату врага по вертикали: ", 0, 9);

                                        Character enemy = null;
                                        bool guzlicInList = false;

                                        if (personaj.Lager == 1)
                                        {
                                            foreach (Character guzlic in BlueLager)
                                            {

                                                if (x == guzlic.X && y == guzlic.Y)
                                                {
                                                    enemy = guzlic;
                                                    foreach (Character guz in list)
                                                    {
                                                        if (guz == enemy)
                                                        {
                                                            guzlicInList = true;
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                        else
                                        {
                                            foreach (Character guzlic in RedLager)
                                            {

                                                if (x == guzlic.X && y == guzlic.Y)
                                                {
                                                    enemy = guzlic;
                                                    foreach (Character guz in list)
                                                    {
                                                        if (guz == enemy)
                                                        {
                                                            guzlicInList = true;
                                                        }
                                                    }
                                                }
                                            }

                                        }
                                        if (!guzlicInList)
                                        {
                                            Console.WriteLine("Координаты не верны");
                                            break;
                                        }
                                        if (enemy == null)
                                        {
                                            Console.WriteLine("Враг не найден");
                                            break;
                                        }

                                        foreach (Character friend in FindFriend(personaj))
                                        {
                                            friend.Attack(FindFriend(enemy));
                                        }

                                        break;
                                    }
                                case 3:
                                    {
                                        personaj.MaxHealthCheck();
                                        break;
                                    }
                            }
                        }
                    }
                    break;
                case 3:
                    {
                        foreach (Character guzlic in RedLager)
                        {
                            guzlic.Info();
                        }
                        Console.WriteLine();
                        foreach (Character guzlyach in BlueLager)
                        {
                            guzlyach.Info();
                        }
                        break;
                    }
                case 4:
                    {
                        return;
                    }
            }
        }
    }

    static void NewCharacter()
    {
        if (CorrectInt("Введите лагерь (1 - красный, 2 - синий): ", 1, 2) == 1)
        {
            Console.WriteLine();
            NewCharacterRed();
        }
        else
        {
            Console.WriteLine();
            NewCharacterBlue();
        }
    }

    static void NewCharacterRed()
    {
        int number = RedLager.Count;
        int damage = CorrectInt("Введите урон персонажа(от 1 до 100): ", 1, 100);
        int health = CorrectInt("Введите здоровье персонажа(от 1 до 250): ", 1, 250);
        int x = CorrectInt("Введите координату по горизонтали: ", 0, 9);
        int y = CorrectInt("Введите координату по вертикали: ", 0, 9);
        RedLager.Add(new CharacterRed(number, damage, health, x, y));
    }

    static void NewCharacterBlue()
    {
        int number = RedLager.Count;
        int damage = CorrectInt("Введите урон персонажа(от 1 до 100): ", 1, 100);
        int health = CorrectInt("Введите здоровье персонажа(от 1 до 250): ", 1, 250);
        int x = CorrectInt("Введите координату по горизонтали: ", 0, 9);
        int y = CorrectInt("Введите координату по вертикали: ", 0, 9);
        BlueLager.Add(new CharacterBlue(number, damage, health, x, y));
    }

    public static int CorrectInt(string abc, int min, int max)
    {
        bool isCorrect;
        int value;
        do
        {
            Console.Write(abc);
            isCorrect = int.TryParse(Console.ReadLine(), out value);
            if (!isCorrect || value < min || value > max)
            {
                Console.WriteLine("Некорректный ввод");
            }
        } while (!isCorrect || value < min || value > max);
        return value;
    }

    static List<Character> FindFriend(Character c)
    {
        List<Character> list = [];
        list.Add(c);

        List<Character> lager;
        if (c.Lager == 1)
            lager = new(RedLager);
        else
        {
            lager = new(BlueLager);
        }
        foreach (Character personaj in lager)
        {
            if (c.X - 1 == personaj.X && c.Y - 1 == personaj.Y || c.X - 1 == personaj.X && c.Y == personaj.Y || c.X - 1 == personaj.X && c.Y + 1 == personaj.Y || c.X == personaj.X && c.Y + 1 == personaj.Y || c.X + 1 == personaj.X && c.Y + 1 == personaj.Y || c.X + 1 == personaj.X && c.Y == personaj.Y || c.X + 1 == personaj.X && c.Y - 1 == personaj.Y || c.X == personaj.X && c.Y - 1 == personaj.Y)
            {
                list.Add(personaj);
            }
        }
        return list;
    }

    static List<Character> FindEnemy(Character c)
    {
        List<Character> group = [];


        List<Character> lager;
        if (c.Lager == 1)
            lager = new(BlueLager);
        else
            lager = new(RedLager);

        foreach (Character personaj in lager)
        {

            if (c.X - 1 == personaj.X && c.Y - 1 == personaj.Y || c.X - 1 == personaj.X && c.Y == personaj.Y || c.X - 1 == personaj.X && c.Y + 1 == personaj.Y || c.X == personaj.X && c.Y + 1 == personaj.Y || c.X + 1 == personaj.X && c.Y + 1 == personaj.Y || c.X + 1 == personaj.X && c.Y == personaj.Y || c.X + 1 == personaj.X && c.Y - 1 == personaj.Y || c.X == personaj.X && c.Y - 1 == personaj.Y)
            {
                group.Add(personaj);
            }
        }
        return group;
    }
}