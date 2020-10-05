using System;

namespace Task_03
{
    class Program
    {
        static void Main(string[] args)
        {
            int N;
            int K;
            Console.WriteLine("Введите N, а затем  K (1 ≤ K ≤ N)");

            while (!int.TryParse(Console.ReadLine(), out N) ||
                !int.TryParse(Console.ReadLine(), out K) || N < K || K < 1)
            {
                Console.WriteLine("Incorrect input");
            }

            int[] A = new int[N];
            FillRandomArray(ref A);

            int factor = K;
            while (K <= N)
            {
                K -= 1;
                Console.Write(A[K] + " ");
                K += factor;
            }
        }

        /// <summary>
        /// Метод заполняет массив random числами.
        /// </summary>
        private static void FillRandomArray(ref int[] A)
        {
            Random random = new Random();
            for (int i = 0; i < A.Length; i++)
            {
                A[i] = random.Next();
            }
        }
    }
}
