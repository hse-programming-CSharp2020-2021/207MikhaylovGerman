using System;

namespace Task_3
{
    struct Rectangle : IComparable<Rectangle>
    {
        public int A { get; set; }
        public int B { get; set; }

        public int Square
        {
            get
            {
                return A * B;
            }
        }

        public int CompareTo(Rectangle other)
        {
            if (this.Square < other.Square)
                return 1;
            else if (this.Square > other.Square)
                return -1;
            else
                return 0;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
