using System;

namespace Classwork_01
{
    class Program
    {
        static void Array(int[] array, int N, int a, int b)
        {
            var random = new Random();

            for (int i = 0; i < N; i++)
            {
                array[i] = random.Next(a, b + 1);
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Введите длину массива ");
            int N;
            if (!int.TryParse(Console.ReadLine(), out N))
            {
                Console.WriteLine("Incorrect input");
            }
            int a, b;
            Console.WriteLine("Введите границы рандома ");
            if (!int.TryParse(Console.ReadLine(), out a) |
                !int.TryParse(Console.ReadLine(), out b))
            {
                Console.WriteLine("Incorrect input");
            }

            int[] array = new int[N];
            Program.Array(array, N, a, b);
            for (int i = 0; i < N; i++)
            {
                Console.WriteLine(array[i] + " ");
            }

        }
    }
}
