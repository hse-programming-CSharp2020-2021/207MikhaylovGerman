using System;

namespace Task_02
{
    class Program
    {
        static void Main(string[] args)
        {
            byte a = 94;
            byte b = 15;
            Console.WriteLine(a^b);
            Console.WriteLine(a >> 2);
            Console.WriteLine(a << 2);
            Console.WriteLine(a | b);
            Console.WriteLine(a & b);
        }
    }
}
