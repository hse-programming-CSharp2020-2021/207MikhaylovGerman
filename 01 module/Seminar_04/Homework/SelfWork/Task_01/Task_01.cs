using System;

namespace SelfWork
{
    class Program
    {
        private static void Main(string[] args)
        {
            // повтор решения.
            do
            {
                // условие.
                Console.WriteLine("a^2 + b^2 = c^2 |  a  |  b  |  c   ");
                Function();

                Console.WriteLine("To exit press ESC...");
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }
        /// <summary>
        /// Метод печатает такие пары: a^2 + b^2 = c^2.
        /// </summary>
        private static void Function()
        {
            for (int i = 1; i < 21; i++)
            {
                for (int j = 1; j < 21; j++)
                {
                    for (int k = 1; k < 21; k++)
                    {
                        if (i * i + j * j == k * k)
                        {
                            Console.WriteLine($"{i}^2 + {j}^2 = {k}^2| {i} | {j} | {k} ");
                        }
                    }
                }
            }
        }
    }
}
