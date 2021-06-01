using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace Task_2
{
    class TriangleNumbs
    {
        public IEnumerable<double> GetEnumerable(int n)
        {
            for (int current = 0; current < n; current++)
            {
                yield return 0.5 * current * (current + 1);
            }
            
        }

    }

    class Fibbonacci
    {
        private int prev;
        private int current;

        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }

        internal IEnumerable nextMemb(int v)
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
            TriangleNumbs tn = new TriangleNumbs();

            foreach (int numb in fi.nextMemb(7))
                Console.Write(numb + "  ");

            Console.WriteLine();


            foreach (int numb in fi.nextMemb(7))
                Console.Write(numb + "  ");

            Console.WriteLine($"{Environment.NewLine}----------------------------------");

            foreach (int numb in tn.GetEnumerable(7))
                Console.Write(numb + "  ");

            Console.WriteLine();

            foreach (int numb in tn.GetEnumerable(7))
                Console.Write(numb + "  ");

            Console.WriteLine();

        }
    }
}
