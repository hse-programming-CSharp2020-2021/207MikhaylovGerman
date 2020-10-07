using System;
using System.Linq;

namespace Homework_01
{
    class MainClass
    {

        private static void Main(string[] args)
        {
            int N;
            do
            {
                Console.WriteLine("Введите  N");
            } while (!int.TryParse(Console.ReadLine(), out N));

            int[,] Array1 = new int[N, N];
            FillArray(ref Array1);
            PrintArray(ref Array1);
        }

        /// <summary>
        /// Метод печатает элементы на экран.
        /// </summary>
        /// <param name="Array"></param>
        private static void PrintArray(ref int[,] Array1)
        {
            for (int i = 0; i < Array1.GetLength(0); i++, Console.WriteLine())
            {
                for (int k = 0; k < Array1.GetLength(1); k++)
                {
                    Console.Write(Array1[i, k] + "\t");
                }

            }
        }

        /// <summary>
        /// Метод заполняет массив числами.
        /// </summary>
        /// <param name="Array"></param>
        private static void FillArray(ref int[,] Array1)
        {
            for (int i = 0; i < Array1.GetLength(0); i++)
            {
                for (int k = 0; k < Array1.GetLength(1); k++)
                {
                    if (i == k)
                    {
                        Array1[i, k] = 0;
                    }
                    else if (k > i)
                    {
                        Array1[i, k] = 1;
                    }
                    else
                    {
                        Array1[i, k] = -1;
                    }
                }
            }
        }
    }
}
