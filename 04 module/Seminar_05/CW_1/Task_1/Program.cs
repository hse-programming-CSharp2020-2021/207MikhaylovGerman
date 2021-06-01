using System;
using System.Collections.Generic;
using System.Linq;

namespace Task_1
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Random random = new Random();

            var numbers = new List<int>();

            for (int i = 0; i < n; i++)
            {
                numbers.Add(random.Next(-1000, 1000));
            }

            var powTwo = from number in numbers
                         select number * number;

            foreach (var item in powTwo)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
            var posAnd2digits = from number in numbers
                                where number.ToString().Length == 2 && number > 0
                                select number;

            foreach (var item in posAnd2digits)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
            var positive = from number in numbers
                                where number > 0
                                orderby number ascending
                                select number;

            foreach (var item in positive)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
            var groupping = from number in numbers
                            group number by number.ToString().Length into ggroup
                            orderby ggroup.Key descending
                            select new { Length = ggroup.Key, Number = ggroup};


            foreach (var item in groupping)
            {
                Console.WriteLine($"Длина: {item.Length}, {item.Number}");
            }
            Console.WriteLine();
        }
    }
}
