using System;
using System.Text;
namespace Task_02
{
    class Program
    {
        /// <summary>
        /// Метод суммирует введенные числа и их количество, а ткаже проверяет их корректность.
        /// </summary>
        /// <param name="sum"></param>
        /// <param name="counter"></param>
        private static void SumNegNum(ref int sum, ref int counter)
        {
            if (int.TryParse(Console.ReadLine(), out int number) && number < 0)
            {
                sum += number;
                counter++;
            }
            else
            {
                Console.WriteLine("Incorrect input");
            }

        }
        private static void Main(string[] args)
        {
            do
            {
                int sum = 0;
                int counter = 0;
                while (true)
                {
                    Console.WriteLine("Type your number");
                    SumNegNum(ref sum, ref counter);

                    Console.WriteLine("To exit press ESC or type your number");
                    // проверка клавиши.
                    if (Console.ReadKey(true).Key == ConsoleKey.Escape || sum < -999)
                    {
                        Console.WriteLine($"Averege number {sum * 1.0 / counter}");
                        break;
                    }
                }

                Console.WriteLine("To exit press ESC ");
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);

        }
    }
}
