using System;
using static System.Math;
using System.IO;
using System.Threading.Tasks;


namespace Chess
{
    class Program
    {
        

        static void Main()
        {
            string writePath = @"C:\Users\User\Documents\GitHub\Chess\hta.txt";

            string text = "Программа запустилась";
            try
            {
                using (StreamWriter sw = new StreamWriter(writePath, false, System.Text.Encoding.Default))
                {
                    sw.WriteLine(text);
                }

                using (StreamWriter sw = new StreamWriter(writePath, true, System.Text.Encoding.Default))
                {
                    sw.WriteLine("Программа запустилась");
                }
                Console.WriteLine("Запись выполнена");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            string[,] deskMain = new string[8, 8];
            BuildingDesk(deskMain);
            int a = 0;
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("1 - Являются ли поля, полями одного цвета");
            Console.WriteLine("2 - Угрожает ли фигура полю");
            Console.WriteLine("3 - Выяснить как попасть на поле за 2 хода");
            Console.WriteLine("Введите ваш выбор");
            a = Convert.ToInt32(Console.ReadLine());


            if (a == 1)
            {
                DetermingColor(deskMain);
            }

            else if (a == 2)
            {
                SecondTask(deskMain);
            }

            else if (a == 3)
            {
                thirdTask(deskMain);
            }

            else
            {
                Console.WriteLine("Неверный ввод, попробуйте снова");
                Console.WriteLine("Не забудь доработать ошибку идиот");
            }
            using (StreamWriter sw = new StreamWriter(writePath, true, System.Text.Encoding.Default))
            {
                sw.WriteLine("Программа завершила работу");
            }
        }


        static void BuildingDesk(string[,] deskMain)
        {

            Console.Write("  1 2 3 4 5 6 7 8");

            for (int i = 1; i < 9; i = i + 1)
            {
                Console.WriteLine();
                Console.Write(i);
                for (int j = 1; j < 9; j = j + 1)
                {
                    if ((deskMain[i - 1, j - 1] != "██") && (deskMain[i - 1, j - 1] != "  ") && (deskMain[i - 1, j - 1] != default))
                    {
                        Console.BackgroundColor = ConsoleColor.Green;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.Write(" ");
                        Console.Write(deskMain[i - 1, j - 1]);
                        Console.ResetColor();
                    }

                    else if ((i + j) % 2 == 0)
                    {
                        deskMain[i - 1, j - 1] = "██";
                        Console.Write(deskMain[i - 1, j - 1]);
                    }

                    else
                    {
                        deskMain[i - 1, j - 1] = "  ";
                        Console.Write(deskMain[i - 1, j - 1]);
                    }
                }
            }
        }

        static void DetermingColor(string[,] deskMain)
        {
            int firstcell_x;
            int secondsell_x;
            int firstcell_y;
            int secondcell_y;

            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("Введите координаты первой ячейки через enter");
            firstcell_x = Convert.ToInt32(Console.ReadLine());
            firstcell_y = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите координаты второй ячейки через enter");
            secondsell_x = Convert.ToInt32(Console.ReadLine());
            secondcell_y = Convert.ToInt32(Console.ReadLine());

            if ((firstcell_x + firstcell_y) % 2 == (secondsell_x + secondcell_y) % 2)
            {
                Console.WriteLine("Поля - одного цвета");
            }

            else
            {
                Console.WriteLine("Поля - разных цветов");
            }
            deskMain[firstcell_x - 1, firstcell_y - 1] = "1";
            deskMain[secondsell_x - 1, secondcell_y - 1] = "2";
            BuildingDesk(deskMain);
        }

        static void SecondTask(string[,] deskMain)           // я знаю что это должен быть глагол, но не знаю как назвать
        {
            Console.Clear();
            Console.WriteLine("Выберите фигуру");
            int a = 0;
            Console.WriteLine("1 - Ферзь");
            Console.WriteLine("2 - Ладья");
            Console.WriteLine("3 - Слон");
            Console.WriteLine("4 - Конь");
            a = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите начальную координату фигуры");
            int firstcell_x = Convert.ToInt32(Console.ReadLine());
            int firstcell_y = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Введите конечную координату фигуры");
            int secondsell_x = Convert.ToInt32(Console.ReadLine());
            int secondcell_y = Convert.ToInt32(Console.ReadLine());

            if (a == 1)
            {
                if (((Abs(firstcell_x - secondsell_x) == Abs(firstcell_y - secondcell_y)) || (firstcell_x == secondsell_x) || (firstcell_y == secondcell_y)))
                {
                    Console.WriteLine("Фигура может достигнуть данной клетки");
                }

                else
                {
                    Console.WriteLine("Фигура не может достигнуть данной клетки");
                }
            }
            else if (a == 2)
            {
                if ((firstcell_x == secondsell_x) || (firstcell_y == secondcell_y))
                {
                    Console.WriteLine("Фигура может достигнуть данной клетки");
                }
                else
                {
                    Console.WriteLine("Фигура не может достигнуть данной клетки");
                }
            }
            else if (a == 3)
            {
                if (Abs(firstcell_x - secondsell_x) == Abs(firstcell_y - secondcell_y))
                {
                    Console.WriteLine("Фигура может достигнуть данной клетки");
                }
                else
                {
                    Console.WriteLine("Фигура не может достигнуть данной клетки");
                }
            }
            else if (a == 4)
            {
                if ((Abs(firstcell_x - secondsell_x) == 1) && ((Abs(firstcell_y - secondcell_y) == 2)) || ((Abs(firstcell_x - secondsell_x) == 2) && ((Abs(firstcell_y - secondcell_y) == 1))))
                {
                    Console.WriteLine("Фигура может достигнуть данной клетки");
                }
                else
                {
                    Console.WriteLine("Фигура не может достигнуть данной клетки");
                }
            }
            else
            {
                Console.WriteLine("Не забудь доработать ошибку идиот");
            }

            deskMain[firstcell_x - 1, firstcell_y - 1] = "1";
            deskMain[secondsell_x - 1, secondcell_y - 1] = "2";
            BuildingDesk(deskMain);
        }

        static void thirdTask(string[,] deskMain)
        {
            Console.Clear();
            Console.WriteLine("Выберите фигуру");
            int a = 0;
            Console.WriteLine("1 - Ферзь");
            Console.WriteLine("2 - Ладья");
            Console.WriteLine("3 - Слон");
            Console.WriteLine("4 - Конь");
            a = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите начальную координату фигуры");
            int firstcell_x = Convert.ToInt32(Console.ReadLine());
            int firstcell_y = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Введите конечную координату фигуры");
            int secondsell_x = Convert.ToInt32(Console.ReadLine());
            int secondcell_y = Convert.ToInt32(Console.ReadLine());

            if (a == 1)
            {
                for (int x = 1; x < 9; x++)
                {
                    for (int y = 1; y < 9; y++)
                    {
                        if ((((Abs(firstcell_x - x) == Abs(firstcell_y - y)) || (firstcell_x == x) || (firstcell_y == y))) && (((Abs(x - secondsell_x) == Abs(y - secondcell_y)) || (x == secondsell_x) || (y == secondcell_y))))
                        {
                            Console.WriteLine("Фигура может достигнуть данной клетки в любом случае, лол");
                            deskMain[firstcell_x - 1, firstcell_y - 1] = "1";
                            deskMain[x - 1, y - 1] = "2";
                            deskMain[secondsell_x - 1, secondcell_y - 1] = "3";
                            BuildingDesk(deskMain);
                            goto LoopEnd;

                        }
                    }
                }

            }

            if (a == 2)
            {
                for (int x = 1; x < 9; x++)
                {
                    for (int y = 1; y < 9; y++)
                    {
                        if (((firstcell_x == x) || (firstcell_y == y)) && ((x == secondsell_x) || (y == secondcell_y)))
                        {
                            Console.WriteLine("Фигура может достигнуть данной клетки в любом случае, лол");
                            deskMain[firstcell_x - 1, firstcell_y - 1] = "1";
                            deskMain[x - 1, y - 1] = "2";
                            deskMain[secondsell_x - 1, secondcell_y - 1] = "3";
                            BuildingDesk(deskMain);
                            goto LoopEnd;

                        }
                    }
                }

            }

            if (a == 3)
            {
                for (int x = 1; x < 9; x++)
                {
                    for (int y = 1; y < 9; y++)
                    {
                        if ((Abs(firstcell_x - x) == Abs(firstcell_y - y)) && ((Abs(x - secondsell_x) == Abs(y - secondcell_y))))
                        {
                            Console.WriteLine("Фигура может достигнуть данной клетки");
                            deskMain[firstcell_x - 1, firstcell_y - 1] = "1";
                            deskMain[x - 1, y - 1] = "2";
                            deskMain[secondsell_x - 1, secondcell_y - 1] = "3";
                            BuildingDesk(deskMain);
                            goto LoopEnd;

                        }
                    }
                }
                Console.WriteLine("Фигура не может достичь данной клетки");
                deskMain[firstcell_x - 1, firstcell_y - 1] = "1";
                deskMain[secondsell_x - 1, secondcell_y - 1] = "2";
                BuildingDesk(deskMain);
            }

            if (a == 4)
            {
                for (int x = 1; x < 9; x++)
                {
                    for (int y = 1; y < 9; y++)
                    {
                        if (((Abs(firstcell_x - x) == 1) && ((Abs(firstcell_y - y) == 2))) && (((Abs(x - secondsell_x) == 1) && ((Abs(y - secondcell_y) == 2)) || ((Abs(x - secondsell_x) == 2) && ((Abs(y - secondcell_y) == 1))))))
                        {
                            Console.WriteLine("Фигура может достигнуть данной клетки");
                            deskMain[firstcell_x - 1, firstcell_y - 1] = "1";
                            deskMain[x - 1, y - 1] = "2";
                            deskMain[secondsell_x - 1, secondcell_y - 1] = "3";
                            BuildingDesk(deskMain);
                            goto LoopEnd;

                        }
                        else if ((((Abs(firstcell_x - x) == 2) && ((Abs(firstcell_y - y) == 1))) && (((Abs(x - secondsell_x) == 1) && ((Abs(y - secondcell_y) == 2)) || ((Abs(x - secondsell_x) == 2) && ((Abs(y - secondcell_y) == 1)))))))
                        {
                            Console.WriteLine("Фигура может достигнуть данной клетки");
                            deskMain[firstcell_x - 1, firstcell_y - 1] = "1";
                            deskMain[x - 1, y - 1] = "2";
                            deskMain[secondsell_x - 1, secondcell_y - 1] = "3";
                            BuildingDesk(deskMain);
                            goto LoopEnd;
                        }
                    }
                }
                Console.WriteLine("Фигура не может достичь данной клетки");
                deskMain[firstcell_x - 1, firstcell_y - 1] = "1";
                deskMain[secondsell_x - 1, secondcell_y - 1] = "2";
                BuildingDesk(deskMain);
            }




        LoopEnd:;
            Console.WriteLine();
            Console.WriteLine("The end (Слава богу)");

        }
    }
}

   
