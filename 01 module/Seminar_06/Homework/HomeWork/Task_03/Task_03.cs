using System;

namespace Task_03
{
    class Program
    {
        /// <summary>
        /// Метод сжимает массив.
        /// </summary>
        private static void RepeaterOfShrinking(ref int[] Array1)
        {
            int N = Array1.Length;
            int counter = 0;
            bool flag = false;
            for (int i = 0; i < N - 1; i++)
            {
                ShrinkingOfArray(ref Array1, N, ref counter, ref flag, i);
            }
            Console.WriteLine($"Проведено операций {counter}");
            if (!flag)
            {
                Console.WriteLine("Массив сжать невозможно!");
            }

        }

        private static void ShrinkingOfArray(ref int[] Array1, int N, ref int counter, ref bool flag, int i)
        {
            if (Array1[i] % 3 == 0 && Array1[i + 1] % 3 == 0)
            {
                flag = true;
                Array1[i] = Array1[i] * Array1[i + 1];
                counter++;
                for (int k = i + 1; k < N - 1; k++)
                {
                    Array1[k] = Array1[k + 1];
                }
                Array.Resize(ref Array1, N - 1);
            }
        }

        private static void Main(string[] args)
        {
            Console.WriteLine("Введите  N");
            int N;
            while (!int.TryParse(Console.ReadLine(), out N))
            {
                Console.WriteLine("Incorrect input");
            }

            int[] Array1 = new int[N];
            FillRandomArray(ref Array1);
            RepeaterOfShrinking(ref Array1);
            PrintArray(ref Array1);
        }

        /// <summary>
        /// Метод печатает элементы на экран.
        /// </summary>
        private static void PrintArray(ref int[] Array1)
        {
            Array.ForEach(Array1, x => Console.Write(x + " "));
        }

        /// <summary>
        /// Метод заполняет массив random числами от MinValue до MaxValue.
        /// </summary>
        private static void FillRandomArray(ref int[] Array1)
        {
            Random random = new Random();
            int MinValue = -10;
            int MaxValue = 10;
            for (int i = 0; i < Array1.Length; i++)
            {
                Array1[i] = random.Next(MinValue, MaxValue);
            }
        }
    }
}
