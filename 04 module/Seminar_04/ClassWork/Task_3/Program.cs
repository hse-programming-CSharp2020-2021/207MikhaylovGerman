using System;
using System.Collections;
using System.Collections.Generic;

namespace Task_3
{
    class Program
    {
        static void Main()
        {

            Evens ev = new Evens(20, 43);

            foreach (var t in ev.GetEnumerator())
                Console.Write(t + "  ");

            Console.WriteLine();

            Console.ReadKey();

        }
    }

    internal class Evens
    {
        private int min;
        private int max;

        public Evens(int v1, int v2)
        {
            min = v1;
            max = v2;
        }

        internal IEnumerable<int> GetMyEnumerator()
        {
            for (int i = min; i < max; i++)
            {
                if (i % 2 == 0)
                    yield return i;
            }
        }
    }
}
