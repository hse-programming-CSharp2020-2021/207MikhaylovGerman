using System;
using System.Collections;
using System.Collections.Generic;

namespace Seminar_last
{
    class LucasCollection : IEnumerable<int>
    {
        int length;

        public LucasCollection(int n)
        {
            length = n;
        }
        public IEnumerator<int> GetEnumerator()
        {
            return new LucasCollectionEnumerator(length);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return new LucasCollectionEnumerator(length);
        }
    }

    sealed class LucasCollectionEnumerator : IEnumerator<int>
    {
        int l1 = 2;
        int l2 = 1;
        private int length;
        int current;
        int currentPos = -1;

        public LucasCollectionEnumerator(int length)
        {
            this.length = length;
        }

        public int Current
        {
            get
            {
                if (currentPos == 0)
                    return l1;
                else if (currentPos == 1)
                    return l2;
                else
                {
                    return current;
                }
            }
        }

        object IEnumerator.Current => current;

        public void Calculate()
        {
            current = l1 + l2;
            l2 = l1;
            l1 = current;
        }

        public void Dispose()
        {
        }

        public bool MoveNext()
        {
            if (currentPos++ == length - 1)
                return false;
            else if (currentPos > 1)
                Calculate();

            return true;
        }

        public void Reset()
        {
            l1 = 2;
            l2 = 1;
            currentPos = -1;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            LucasCollection lc = new LucasCollection(n);
            foreach (var item in lc)
            {
                Console.WriteLine(item);
            }
        }
    }
}
