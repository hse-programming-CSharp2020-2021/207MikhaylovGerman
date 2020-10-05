using System;

namespace Task_02
{
    class Program
    {
        private static void FillArray(ref int[] Array1)
        {
            for (int i = 0; i < Array1.Length; i++)
            {
                Array1[i] = S(i);
            }

        }
        /// <summary>
        /// Метод вохваращает треугольное n- ое число.
        /// </summary>
        private static int S(int n)
        {
            if (n == 0)
            {
                return 0;
            }
            else if (n == 1)
            {
                return 1;
            }
            else
            {
                return 34 * S(n - 1) - S(n - 2) + 2;
            }
             
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Введите  N");
            int N;
            while (!int.TryParse(Console.ReadLine(), out N))
            {
                Console.WriteLine("Incorrect input");
            }

            int[] Array1 = new int[N];
            FillArray(ref Array1);
            Array.ForEach(Array1, i => Console.Write(i + " "));

        }
    }
}
