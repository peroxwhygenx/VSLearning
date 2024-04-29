using System;

class Program
{
    static void Main(string[] args)
    {
        StartGame();// Вызов запуска игры
    }

    static void StartGame()
    {
        Console.WriteLine("Приветствую тебя в игре 'BuckShot'!");
        Console.WriteLine("Введи своё имя: ");
        string playerName = Console.ReadLine();
        Console.WriteLine($"Ну что же, приступим, {playerName}!");

        bool playAgain = true;
        while (playAgain)
        {
            //Определяем порядок хода
            Random random = new Random();
            bool userGoesFirst = random.Next(2) == 0;

            int currentPlayerSlot = 0;

            if (userGoesFirst)
            {
                Console.WriteLine($"Игрок {playerName} ходит первым!");
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("Компьютер ходит первым!");
            }

            //Создаем револьвер и барабан, в который рандомно вставляем патрон
            bool[] revolver = new bool[6];
            int bulletPosition = random.Next(6);
            revolver[bulletPosition] = true;

            Console.WriteLine($"Патрон заряжен в {bulletPosition + 1} слот");

            //Логика игрового процесса
            bool gameOver = false;
            bool userTurn = userGoesFirst;
            int attempts = 0;

            while (!gameOver)
            {
                attempts++;
                int currentSlot = currentPlayerSlot % 6 + 1;
                currentPlayerSlot++;

                if (userTurn)
                {
                    Console.WriteLine();
                    Console.WriteLine($"{playerName}, У тебя слот № {currentSlot} Твой ход. Что бы выстрелить, нажми 'Enter'!");
                    Console.ReadLine();
                    Console.WriteLine("Выстрел!");

                    //Проверка на выстрел
                    if (revolver[currentSlot -1])
                    {
                        Console.WriteLine($"BANG! {playerName}, Твои мозги забрызгали все стены! Тебе понадоблось {attempts} ходов для этого.");
                        gameOver = true;
                    }
                    else
                    {
                        Console.WriteLine("Повезло, повезло. Переход хода!");
                        userTurn = false;
                    }
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine($"Ход компьютера! Его слот {currentSlot}. ");

                    Console.WriteLine("Этот железный идиот собирается с мыслями...");
                    System.Threading.Thread.Sleep(2000); //Нашел в интернете что это задать таймаут. Для правдоподобности вставил)))

                    Console.WriteLine("Компьютер делает выстрел, и....");
                    if (revolver[currentSlot - 1])
                    {
                        Console.WriteLine($"И только микросхемы по стенках! Железный болванчик проиграл! Ему понадоблось {attempts} ходов для этого.");
                        gameOver = true;
                    }
                    else
                    {
                        Console.WriteLine($"Пронесло железяку!");
                        userTurn = true;
                    }

                }
            }

            Console.WriteLine($"Сыграем еще раз, {playerName}? Напиши y/n.");
            string answer = Console.ReadLine().ToLower();
            playAgain = (answer == "y");
        }

        Console.WriteLine($"Нет, так нет. До встречи {playerName}.");
    }
}

