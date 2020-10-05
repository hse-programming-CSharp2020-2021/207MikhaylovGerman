using System;

namespace Task_04
{
    class Program
    {
        static void Main(string[] args)
        {
            int N;
            while (!int.TryParse(Console.ReadLine(), out N))
            {
                Console.WriteLine("Incorrect input");
            }

            int[] A = new int[];
            FillRandomArray(ref A);

            int indexOfMin = 0;
            int indexOfMax = 0;
            int minValue = int.MaxValue;
            int maxValue = int.MinValue;
            for (int i = 0; i < A.Length; i++)
            {
                if (A[i] < minValue)
                {
                    minValue = A[i];
                    indexOfMin = i;
                }
                else if (A[i] >= maxValue)
                {
                    maxValue = A[i];
                    indexOfMax = i;
                }
            }

            Console.WriteLine($"Индекс минимального элемента массива {indexOfMin}");
            Console.WriteLine($"Сумма индексов минимального и максимального элемента {indexOfMin + indexOfMax}");


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
