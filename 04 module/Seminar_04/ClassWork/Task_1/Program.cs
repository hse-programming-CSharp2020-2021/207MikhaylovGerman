using System;
using System.Collections.Generic;

namespace Task_1
{
    class Fibbonacci
    {
        private int prev;
        private int current;


        private int Fibonachi(int n)
        {
            if (n <= 0)
                return 0;
            else if (n == 1)
                return 1;
            else
                return Fibonachi(n - 1) + Fibonachi(n - 2);
        }

        internal IEnumerable<int> nextMemb(int v)
        {
            for (int i = 0; i < v; i++)
            {
                int temp = current;
                current += prev;
                prev = temp;
                yield return current;
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Fibbonacci fi = new Fibbonacci();

            foreach (int numb in fi.nextMemb(7))
                Console.Write(numb + "  ");

            Console.WriteLine();



            foreach (int numb in fi.nextMemb(7))
                Console.Write(numb + "  ");

            Console.WriteLine();
        }
    }
}
