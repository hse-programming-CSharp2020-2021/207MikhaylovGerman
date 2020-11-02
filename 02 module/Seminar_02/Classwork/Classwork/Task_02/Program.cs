using System;

namespace Task_02
{
    class LatinChar
    {
        private char _char = 'a';

        public int Char(char symbol)
        {
            _char = symbol;
            return _char;
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            LatinChar latinChar = new LatinChar();

            char minChar = char.Parse(Console.ReadLine());
            char maxChar = char.Parse(Console.ReadLine());
            for (char i = minChar; i < maxChar; i++)
            {
                Console.WriteLine((char)latinChar.Char(i)); 

            }
        }
    }
}
