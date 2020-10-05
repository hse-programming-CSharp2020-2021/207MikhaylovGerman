using System;

namespace Task_04
{
    class Program
    {
        /// <summary>
        /// Метод вычисляет детерминант(определитель) матрицы 2x2 и 3x3.
        /// </summary>
        /// <param name="array">Массив, определитель которого надо вычислить</param>
        /// <param name="N">Размер матрицы</param>
        /// <returns></returns>
        private static int Determenand(ref int[,] array,int N)
        {
            if (N == 2)
            {
                return (array[0, 0] * array[1, 1]) - (array[0, 1] * array[0, 1]);
            }
            else
            {
                return ((array[0, 0] * array[1, 1] * array[2, 2]) + (array[0, 1] * array[1, 2] * array[2, 0])
                    + (array[0, 2] * array[1, 0] * array[2, 1])) - ((array[0, 0] * array[1, 2] * array[2, 1]) +
                    (array[0, 1] * array[1, 0] * array[2, 2]) + (array[0, 2] * array[1, 1] * array[2, 0]));
            }

        }
        private static void Main(string[] args)
        {
            // Для матрицы 2x2.
            int N = 2;
            int[,] array = new int[N, N];
            InputArray(ref array, N);
            int result = Determenand(ref array, N);
            Console.WriteLine($"Определитель матрицы 2x2 = {result}");

            // Для матрицы 3x3.
            N = 3;
            int[,] array1 = new int[N, N];
            InputArray(ref array1, N);
            int result1 = Determenand(ref array1, N);
            Console.WriteLine($"Определитель матрицы 3x3 = {result1}");

        }

        /// <summary>
        /// Ввод массива с клавиатуры.
        /// </summary>
        /// <param name="array"></param>
        /// <param name="N"></param>
        private static void InputArray(ref int[,] array, int N)
        {
            Console.WriteLine("Введите двумерный массив, используя в качестве разделителя ' ', ',', '.', ':', '\t' ");
            for (int i = 0; i < N; i++)
            {
                for (int k = 0; k < N; k++)
                {
                    Console.WriteLine($"Введите элемент {i + 1} строки, {k + 1} столбца");
                    while (!int.TryParse(Console.ReadLine(), out array[i, k]))
                    {
                        Console.WriteLine("Incorrect input");
                    }
                }
            }
        }
    }
}
