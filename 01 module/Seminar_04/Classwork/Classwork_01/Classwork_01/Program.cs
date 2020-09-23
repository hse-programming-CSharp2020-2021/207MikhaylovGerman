using System;

namespace Classwork_01
{
    class Program
    {
        static bool Triangle(double x, double y, double z, out double p, out double s)
        {
            bool flag = false;
            p = (x + y + z);
            s = 0;
            if (x < y + z && y < x + z && z < x + y)
            {
                flag = true;
                s = Math.Sqrt(p * (p / 2 - x) * (p / 2 - y) * (p / 2 - z));
            }
            else
            {
                flag = false;
            }
            return flag;
        }
        static void Main(string[] args)
        {
            do
            {
                Console.WriteLine("Введите 3 числа(стороны треугольника) ");
                double x, y, z;
                while (!double.TryParse(Console.ReadLine(), out x) ||
                       !double.TryParse(Console.ReadLine(), out y) ||
                       !double.TryParse(Console.ReadLine(), out z))
                {
                    Console.WriteLine("Ошибка ввода, введите 3 числа(стороны треугольника) ");
                }
                double p, s;
                Console.WriteLine(Program.Triangle(x, y, z, out p, out s));
                Console.WriteLine(s);

            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
            



        }
    }
}
