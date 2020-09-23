using System;

namespace Delta
{
    class Program
    {
        static void Main(string[] args)
        {
            // повторение решения 
            do
            {
                Console.WriteLine("Введите A и delta");

                double A;
                int delta;

                // проверка ввода 
                while (!double.TryParse(Console.ReadLine(), out A) |
                       !int.TryParse(Console.ReadLine(), out delta))
                {
                    Console.WriteLine("Ошибка ввода ");
                    Console.WriteLine("Введите A и delta");

                }
                double S = 0;
                int i = 0;
                bool flag = false;
                for (i = 0; i + delta<= A; i += delta)
                {
                    flag = true;
                    S += 0.5 * (Math.Pow(i, 2) + Math.Pow(i + delta, 2)) * delta;
                }
                if (flag)
                {
                    //S += (A-(i - delta))
                }


                Console.WriteLine("Площадь под графиком ={0}", S);




                Console.WriteLine("Нажмите ESC для выхода ");
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }
    }
}
