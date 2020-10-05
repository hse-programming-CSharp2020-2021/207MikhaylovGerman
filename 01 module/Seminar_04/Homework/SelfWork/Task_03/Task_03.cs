using System;

namespace Task_03
{
    class Program
    {
        /// <summary>
        /// Метод печатает тройки чисел.
        /// </summary>
        /// <param name="y">Вывод 1</param>
        /// <param name="x">Вывод 2</param>
        public static void PrintFunction(double a, double b, double c, double y, double x)
        {
            Console.WriteLine($" {a}  |  {b}  |  {c}  |  {x:G3}  |  {y:G8}");
        }

        /// <summary>
        /// Метод является математической системой.
        /// </summary>
        static void Function(double a, double b, double c)
        {
            double y = 0;
            double x = 1;
            while (x < 2.05)
            {
                if (x < 1.2)
                {
                    y = a * (x) * x + b * x + c;
                }
                else if (x == 1.2)
                {
                    y = a / x + Math.Sqrt(x * x + 1);
                }
                else if (x > 1.2)
                {
                    y = (a + b * x) / Math.Sqrt(x * x + 1);
                }
                PrintFunction(a, b, c, y, x);
                x += 0.05;
            }
        }

        static void Main(string[] args)
        {
            double a;
            double b;
            double c;
            do
            { 
                Console.Write("Type a: ");
                while (!double.TryParse(Console.ReadLine(), out a))
                {
                    Console.WriteLine("Incorrect input");
                }
                Console.Write("Type b: ");
                while (!double.TryParse(Console.ReadLine(), out b))
                {
                    Console.WriteLine("Incorrect input");
                }
                Console.Write("Type c: ");
                while (!double.TryParse(Console.ReadLine(), out c))
                {
                    Console.WriteLine("Incorrect input");
                }

                Console.WriteLine("  a  |  b  |  c  |  x  |  y");

                Function(a, b, c);

                Console.WriteLine("To exit press ESC ");
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }
    }
}
