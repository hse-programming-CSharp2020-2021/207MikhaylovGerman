using System;
using System.Linq;

namespace Task_01
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = ArrayOfNumbers();

            var collection1 = from numb in numbers
                              select numb % 10;

            //var collection1 = numbers.Select(numb => numb % 10);

            foreach (var item in collection1)
            {
                Console.WriteLine(item);
            }

            var collection2 = from numb in numbers
                              orderby numb % 10
                              select new { Group = numb % 10, numb };

            //var collection2 = numbers.OrderBy(numb => numb % 10).Select(res => new { Group = res % 10, res });

            foreach (var item in collection2)
            {
                Console.WriteLine($"{item.Group}: {item.numb}");
            }

            var countPosAndEven = (from numb in numbers
                                   where numb > 0 && numb % 2 == 0
                                   select numb).Count();
            //var countPosAndEven = numbers.Where(numb => numb > 0 && numb % 2 == 0).Count();

            Console.WriteLine($"Количество четный и положительных  = {countPosAndEven}");

            var sumEven = (from numb in numbers
                           where numb % 2 == 0
                           select numb).Sum();
            //var sumEven = numbers.Where(numb => numb % 2 == 0).Sum();

            Console.WriteLine($"Сумма положительных = {sumEven}");

        }

        private static int[] ArrayOfNumbers()
        {
            int n = int.Parse(Console.ReadLine());
            Random random = new Random();

            int[] numbers = new int[n];
            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = random.Next(-10000, 10001);
            }

            return numbers;
        }
    }
}
