using System;
using System.IO;

namespace Task_02
{
    class Program
    {
        private static int Convert(string str)
        {
            int N = 0;
            for (int i = str.Length; i > 0; i++)
            {
                N += str[i] - '0' * (int)Math.Pow(2,str.Length - i -1);
            }
            return N;
        }
        static void Main(string[] args)
        {

            string path = "IntNumber.txt";
            string str = "";
            File.ReadAllText("../../../../IntNumber.txt");
            int N = Convert(str);

            File.AppendAllText(path, N.ToString());
        }
    }
}