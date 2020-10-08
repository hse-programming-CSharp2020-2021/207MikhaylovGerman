using System;
using System.IO;

namespace Task_02
{
    class Program
    {
        private static string Method(int N)
        {
            string str = "";
            while (N > 0)
            {
                str = (N % 2).ToString() + str;
                N /= 2;
            }
            return str;
        }
        static void Main(string[] args)
        {
            byte N;
            do
            {
                Console.WriteLine("Введите число ");
            } while (!byte.TryParse(Console.ReadLine(), out N));

            string path = "IntNumber.txt";
            string str = Method(N);

            File.AppendAllText(path, str);
        }
    }
}
