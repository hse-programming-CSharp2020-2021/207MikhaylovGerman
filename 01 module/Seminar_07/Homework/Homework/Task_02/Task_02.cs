using System;

namespace Task_02
{
    class Program
    {
        static void Main(string[] args)
        {
            // Считывание N.
            int N;
            do
            {
                Console.WriteLine("Введите N");
            } while (!int.TryParse(Console.ReadLine(), out N));

            // Алгоритм нахождения количества строк зубчатого массива.
            int copyN = N;
            int k;
            for (k = 0; copyN > 0; k++)
            {
                for (int i = 0; i <= k; i++)
                {
                    copyN -= i;
                }
            }
            int Length = k + 1;

            // Создание массива.
            int[][] Array1 = new int[Length][];

            for (int i = 0; i < Array1.GetLength(0); i++)
            {
                Array1[i] = new int[i + 1];
            }
            // ЗАПОЛНЕНИЕ И ВЫВОД.
            FillArray(ref Array1, N);
            PrintArray(ref Array1);
        }

        /// <summary>
        /// Метод печатает элементы на экран.
        /// </summary>
        /// <param name="Array"></param>
        private static void PrintArray(ref int[][] Array1)
        {
            Console.WriteLine();
            for (int i = 0; i < Array1.GetLength(0); i++, Console.WriteLine())
            {
                for (int k = 0; k < Array1[i].Length; k++)
                {
                    if (Array1[i][k] > 0)
                    {
                        Console.Write(Array1[i][k] + " ");
                    }
                }

            }
        }

        /// <summary>
        /// Метод заполняет массив числами.
        /// </summary>
        /// <param name="Array"></param>
        private static void FillArray(ref int[][] Array1, int N)
        {
            int counter = 0;
            for (int i = 0; i < Array1.Length; i++)
            {
                counter += i;
                for (int j = 0; j < Array1[i].Length; j++)
                {
                    // Рассчет элемента.
                    Array1[i][j] = N - (j + 1) - (counter - 1);
                }
            }
        }
    }
}
