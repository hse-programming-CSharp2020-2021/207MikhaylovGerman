using System;

namespace Task_02
{
    class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Введите  N");
            int N;
            while (!int.TryParse(Console.ReadLine(), out N) || N <= 1)
            {
                Console.WriteLine("Incorrect input");
            }

            int[] Array1 = new int[N];
            FillArray(ref Array1);
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
        /// Метод заполняет массив по математической схеме.
        /// </summary>
        private static void FillArray(ref int[] Array1)
        {
            for (int i = 0; i < Array1.Length; i++)
            {
                if (i == 0)
                {
                    Array1[i] = 0;
                }
                else if (i == 1)
                {
                    Array1[i] = 1;
                }
                else
                {
                    Array1[i] = Array1[i - 1] + Array1[i - 2]; 
                }
            }
        }
    }
}
