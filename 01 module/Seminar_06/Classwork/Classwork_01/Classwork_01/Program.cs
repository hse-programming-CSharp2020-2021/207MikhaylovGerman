using System;

namespace Classwork_01
{
    class Program
    {
        static void ArrayFill(ref char[] array, string input)
        {
            int i = 0;
            foreach (var item in input)
            {
                array[i] = item;
                i ++;
            }
        }
        static void Main(string[] args)
        {
            int N;
            string input = Console.ReadLine();
            if (!int.TryParse(input , out N) || N <= 0)
            {
                Console.WriteLine("Ошибка ввода");
            }
            char[] array = new char[N];
            ArrayFill(ref array, input);
            Array.ForEach(array, x => Console.Write($"{x} "));
        }
    }
}
