using System;
using System.Collections.Generic;

namespace Brackets
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<char> st = new Stack<char>();

            string input = Console.ReadLine();

            bool isCorrect = true;

            foreach (var ch in input)
            {
                if (ch == '{' || ch == '(' || ch == '[')
                {
                    st.Push(ch);
                }
                else
                {
                    if (st.Count == 0)
                    {
                        isCorrect = false;
                        break;
                    }
                    char leftChar = st.Pop();
                    if (leftChar == '(' && ch != ')' || leftChar == '[' && ch != ']' || leftChar == '{' && ch != '}')
                    {
                        isCorrect = false;
                        break;
                    }
                }
            }

            if (st.Count != 0)
                isCorrect = false;

            if (isCorrect)
            {
                Console.WriteLine("Correct");
            }
            else
            {
                Console.WriteLine("Not correct");
            }
        }
    }
}
