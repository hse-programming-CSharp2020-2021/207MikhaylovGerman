using System;

namespace Task_9
{
    class Circle
    {
        int X { get; set; }
        int Y { get; set; }
        int R { get; set; }

        internal int GetX() => X;
        internal int GetY() => Y;
        internal int GetR() => R; 

        public Circle(int x, int y, int r)
        {
            X = x;
            Y = y;
            R = r;
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            do
            {
                // Считываем N.
                int N;
                do
                {
                    Console.WriteLine("Введите N");
                } while (!int.TryParse(Console.ReadLine(), out N));

                Circle[] circle = new Circle[N];

                // Заполняем массив объектами и выводим информацию о них.
                for (int i = 0; i < circle.Length; i++)
                {
                    Random random = new Random();
                    circle[i] = new Circle(random.Next(1, 15), random.Next(1, 15), random.Next(1, 15));
                    Console.WriteLine($"X:{circle[i].GetX()}, Y:{circle[i].GetY()}, R:{circle[i].GetR()} .");
                }

                Random random1 = new Random();
                Circle circle1 = new Circle(random1.Next(1, 15), random1.Next(1, 15), random1.Next(1, 15));

                // Проверяем на пересечение с кругом.ы
                Console.WriteLine($"Пересекающиеся круги с circle: X:{circle1.GetX()}, Y:{circle1.GetY()}, R:{circle1.GetR()}: ");
                for (int i = 0; i < circle.Length - 1; i++)
                {
                    if (Math.Sqrt(Math.Pow(circle1.GetX() - circle[i].GetX(), 2) + Math.Pow(circle1.GetY() - circle[i].GetY(), 2)) < (circle[i].GetR() + circle1.GetR()))
                    {
                        Console.WriteLine($"X:{circle[i].GetX()}, Y:{circle[i].GetY()}, R:{circle[i].GetR()} ");
                    }
                }

                Console.WriteLine("Для выхода нажмите ESC, для продолжения Enter...");
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }
    }
}
