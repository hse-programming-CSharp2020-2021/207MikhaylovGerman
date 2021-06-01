using System;
using System.Collections;

namespace Task_4
{
    public class RandomCollection : IEnumerable
    {
        private int length;
        public RandomCollection(int length)
        {
            this.length = length;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return (IEnumerator)GetEnumerator();
        }

        public RandomEnumerator GetEnumerator()
        {
            return new RandomEnumerator(length);
        }
    }

    public class RandomEnumerator : IEnumerator
    {
        int position = -1;
        private Random rand;
        private int length;


        public RandomEnumerator(int length)
        {
            rand = new Random();
            this.length = length;
        }

        public bool MoveNext() => ++position < length;

        public void Reset() => position = -1;

        object IEnumerator.Current => Current;

        public int Current
        {
            get
            {
                try
                {
                    return rand.Next();
                }
                catch (IndexOutOfRangeException)
                {
                    throw new InvalidOperationException("упс");
                }
            }
        }
    }

    class App
    {
        static void Main()
        {
            RandomCollection intRandom = new RandomCollection(10);
            foreach (var number in intRandom)
                Console.WriteLine(number);
        }
    }

}
