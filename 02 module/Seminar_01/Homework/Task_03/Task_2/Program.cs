using System;

// Задача из презентации про массивы.

namespace Task_2
{
    class Program
    {
        static void Main(string[] args)
        {
            int N;
            do
            {
                do
                {
                    Console.WriteLine("Введите число N ");
                } while (!int.TryParse(Console.ReadLine(), out N));

                double[,] array = new double[N, N];

                // Fill in the array.
                for (int i = 0; i < N; i++)
                {
                    for (int k = 0; k < N; k++)
                    {
                        array[i, k] = (i + k + 1) % N;

                        if (array[i, k] == 0)
                            array[i, k] = N;
                    }
                }

                PrintArray(array);

                Console.WriteLine("Для выхода нажмите Esc, для повторения Enter...");
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }

        /// <summary>
        /// Method prints the array.
        /// </summary>
        /// <param name="array">Array to print.</param>
        private static void PrintArray(double[,] array)
        {   
            for (int i = 0; i < array.GetLength(0); i++, Console.WriteLine())
            {
                for (int k = 0; k < array.GetLength(1); k++)
                {
                    Console.Write(array[i, k] + " ");
                }
            }
        }
    }
}
