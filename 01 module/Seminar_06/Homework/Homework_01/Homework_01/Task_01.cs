using System;
using System.Linq;

namespace Homework_01
{
    class MainClass
    {
        /// <summary>
        /// Метод переставляет элеметны массива.
        /// </summary>
        private static void ArrayHill(ref int[] Array1)
        {
            Array.Sort(Array1);
            int[] result = new int[Array1.Length];
            int NumberOfEvenIndex = 0;
            int NumberOfOddIndex = 0;
            for (int i = 0; i < Array1.Length; i++)
            {
                if (i % 2 == 0)
                {
                    result[i - 1 * NumberOfEvenIndex++] = Array1[i];
                }
                else
                    result[Array1.Length - 1 - NumberOfOddIndex++] = Array1[i];
            }
            //  перекладываем все значния из result в Array1.
            for (int i = 0; i < Array1.Length; i++)
            {
                Array1[i] = result[i];
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
            ArrayHill(ref Array1);
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

