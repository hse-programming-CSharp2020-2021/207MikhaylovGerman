using System;
using System.Linq;

namespace Homework_01
{
    class MainClass
    {

        private static void Main(string[] args)
        {
            Console.WriteLine("Введите  N");
            int N;
            while (!int.TryParse(Console.ReadLine(), out N) || N <= 1)
            {
                Console.WriteLine("Incorrect input");
            }
            Console.WriteLine("Введите A, а затем D ");
            int A;
            int D;
            while (!int.TryParse(Console.ReadLine(), out A) ||
                !int.TryParse(Console.ReadLine(), out D))
            {
                Console.WriteLine("Incorrect input");
            }

            int[] Array1 = new int[N];
            FillArray(ref Array1, A, D);
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
        private static void FillArray(ref int[] Array1, int A, int D)
        {
            for (int i = 0; i < Array1.Length; i++)
            {
                if (i == 0)
                {
                    Array1[i] = A;
                }
                else if (i == 1)
                {
                    Array1[i] = A + D;
                }
                else
                {
                    Array1[i] = A + i * D;
                }
            }
        }
    }
}

