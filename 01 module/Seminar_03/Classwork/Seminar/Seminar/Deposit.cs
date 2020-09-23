using System;

namespace Seminar
{
    class Program
    {   
        // метод вычисляет конечную сумму депозита
        public static void Total(double k, double r, int n, out double result)
        {
            result = k * Math.Pow((1+r/100),n);


        }
        static void Main(string[] args)
        {   // повторение решения 
            do
            {
                Console.WriteLine("Введите сумму начального капитала, годовую процентную ставку и число лет");
                int n;
                double k, r;
                
                // проверка ввода 
                while (!double.TryParse(Console.ReadLine(), out k) |
                       !double.TryParse(Console.ReadLine(), out r) |
                       !int.TryParse(Console.ReadLine(), out n))
                {
                    Console.WriteLine("Ошибка ввода ");
                    Console.WriteLine("Введите начальный капитал, годовую процентную ставку и число лет");

                }
                double result;
                // вызов метода
                Program.Total(k, r, n, out result);
                Console.WriteLine($"Сумма вклада на конец {n} года, по ставке {r}%, равна = {result:F2}");
                



                Console.WriteLine("Нажмите ESC для выхода ");
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }

    }
}
