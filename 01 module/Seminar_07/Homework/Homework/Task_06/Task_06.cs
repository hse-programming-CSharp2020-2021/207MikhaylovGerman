using System;

namespace Task_06
{
    class Program
    {
        /// <summary>
        /// Метод вычисляет два определителя матрицы 3x6.
        /// </summary>
        /// <param name="array"></param>
        /// <param name="result"></param>
        private static void Determenand(int[,] array, out int[] result)
        {
            result = new int[2];
            // Определитель первой половины матрицы.
            result[0] = ((array[0, 0] * array[1, 1] * array[2, 2]) + (array[0, 1] * array[1, 2] * array[2, 0])
                + (array[0, 2] * array[1, 0] * array[2, 1])) - ((array[0, 0] * array[1, 2] * array[2, 1]) +
                (array[0, 1] * array[1, 0] * array[2, 2]) + (array[0, 2] * array[1, 1] * array[2, 0]));
            // Определитель второй половины матрицы.
            result[1] = ((array[0, 3] * array[1, 4] * array[2, 5]) + (array[0, 4] * array[1, 5] * array[2, 3])
                + (array[0, 5] * array[1, 3] * array[2, 4])) - ((array[0, 3] * array[1, 5] * array[2, 4]) +
                (array[0, 4] * array[1, 3] * array[2, 5]) + (array[0, 5] * array[1, 4] * array[2, 3]));
        }

    

        private static void Main(string[] args)
        {
            // Заполнение массива.
            int[,] Array1 = new int[3, 6];
            FillRandomArray(ref Array1);
            // Вычисление двух определителей.
            int[] result;
            Determenand(Array1, out result);

            PrintArray(ref result);
        }

        /// <summary>
        /// Метод печатает элементы на экран.
        /// </summary>
        private static void PrintArray(ref int[] result)
        {
            Console.WriteLine("Детерменанды(определители) ");
            Array.ForEach(result, x => Console.Write(x + " "));
        }

        /// <summary>
        /// Метод заполняет массив random числами от MinValue до MaxValue.
        /// </summary>
        private static void FillRandomArray(ref int[,] Array1)
        {
            Random random = new Random();
            int MinValue = 0;
            int MaxValue = 20;
            for (int i = 0; i < 3; i++)
            {
                for (int k = 0; k < 6; k++)
                {
                    Array1[i, k] = random.Next(MinValue, MaxValue);

                }
            }   
        }
    }
}
