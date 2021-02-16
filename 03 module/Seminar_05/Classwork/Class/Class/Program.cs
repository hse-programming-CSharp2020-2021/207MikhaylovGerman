using System;
using System.Collections.Generic;

namespace Class
{
    class Program
    {
        static void Main(string[] args)
        {
            int input1 = int.Parse(Console.ReadLine());
            int input2 = input1;

            Stack<int> ts = new Stack<int>();
            while (input1 > 0)
            {
                ts.Push(input1 % 10);
                input1 /= 10;
            }
            
            LinkedList<int> list = new LinkedList<int>();
            while (input2 > 0)
            {
                list.AddFirst(input2 % 10);
                input2 /= 10;
            }

            foreach (var item in ts)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
            foreach (var item in list)
            {
                Console.Write(item + " ");
            }
        }
    }
}
