using System;

namespace Task_01
{
    class Program
    {
        static void Array(int[] array1, int[] array2, int N1, int N2, int a, int b)
        {
            var random = new Random();
            for (int i = 0; i < N1; i++)
            {
                array1[i] = random.Next(a, b + 1);
                Console.Write(array1[i] + " ");

            }
            for (int i = 0; i < N2; i++)
            {
                array2[i] = random.Next(a, b + 1);
                Console.Write(array2[i] + " ");

            }
            int[] array_modifided = new int[N1 + N2];
            for (int i = 0; i < N1; i++)
            {
                array_modifided[i] = array1[i];
            }
            for (int i = 0; i < array2.Length; i++)
            {
                if (array2[i] % 2 == 0)
                {
                    array_modifided[N1 + i] = array2[i];
                }
            }
            for (int i = 0; i < array_modifided.Length; i++)
            {
                Console.Write(array_modifided[i] + " ");
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Введите длину массива ");
            int N1, N2;
            if (!int.TryParse(Console.ReadLine(), out N1) |
                !int.TryParse(Console.ReadLine(), out N2))
            {
                Console.WriteLine("Incorrect input");
            }
            // границы массива
            int a = 10;
            int b = 50;
            // массивы
            int[] array1 = new int[N1];
            int[] array2 = new int[N2];

            Program.Array(array1, array2, N1, N2, a, b);


        }
    }
}
