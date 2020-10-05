using System;

namespace Task_04
{
    class Program
    {
        static void Main(string[] args)
        {
            uint M, N;
            do
            {
                Console.Write("Type M: ");
                while (!uint.TryParse(Console.ReadLine(), out M))
                {
                    Console.WriteLine("Incorrect input");
                }
                Console.Write("Type N: ");
                while (!uint.TryParse(Console.ReadLine(), out N))
                {
                    Console.WriteLine("Incorrect input");
                }

                Console.WriteLine($"2^{N} + 2^{M} = {Multiple(M, N)}");

                Console.WriteLine("To exit press ESC");
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }

        /// <summary>
        /// Метод использую операцию быстрого умнодения на 2.
        /// </summary>
        /// <param name="M"></param>
        /// <param name="N"></param>
        /// <returns></returns>
        static public int Multiple(uint M, uint N)
        {
            int firstNumber = N == 0 ? 1 : 2 << (int)N - 1;
            int secondNumber = M == 0 ? 1 : 2 << (int)M - 1;
            return firstNumber + secondNumber;
        }
        
    }
}
