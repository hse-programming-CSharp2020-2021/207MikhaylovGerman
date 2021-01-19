using System;
using System.Collections.Generic;
using System.Linq;

namespace Task_3
{
    class Program
    {
        static void Main(string[] args)
        {
            var actions = new List<Action>();
            foreach (var a in new int[] { 1, 2, 3 })
            {
                actions.Add(() => Console.WriteLine(a));
            }
            foreach (var action in actions)
            {
                action();
            }
            Console.WriteLine("***");
            var actions2 = new List<Action>();
            int i;
            for (i = 1; i <= 3; i++)
            {
                actions2.Add(() => Console.WriteLine(i));
            }

            foreach (var action in actions2)
            {
                action();
            }
            i = 10;
            foreach (var action in actions2)
            {
                action();
            }

            i = 100;
            foreach (var action in actions2)
            {
                action();
            }
            Console.WriteLine("***");
            var actions3 = new List<Action>();
            for (int i1 = 1; i1 <= 3; i1++)
            {
                int j = i1;
                actions3.Add(() => Console.WriteLine(j));
            }

            foreach (var action in actions3)
            {
                action();
            }
            Console.WriteLine("***");
            int[] arr = { 1, 2, 3, 4, 5 };
            var actions4 = new List<Action>();
            int k;
            for (k = 0; k < 5; k++)
            {
                actions4.Add(() => Console.WriteLine(arr[k]));
            }
            k = 4;
            foreach (var action in actions4)
            {
                action();
            }
        }
    }
}
