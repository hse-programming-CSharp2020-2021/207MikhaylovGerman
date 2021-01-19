using System;
using System.Text;

namespace Task_3
{
    delegate string ConvertRule(string input);

    class Converter
    {
        public string Convert(string str, ConvertRule rule)
        {
            return rule(str);
        }
    }

    class Program
    {
        public static string RemoveDigits(string str)
        {
            char[] strArray = str.ToCharArray();
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < strArray.Length; i++)
            {
                if (Char.IsDigit(strArray[i]))
                {
                    builder.Append(strArray[i].ToString());
                }
            }
            return builder.ToString();
        }

        public static string RemoveSpaces(string str) => str.Replace(" ", "");


        static void Main(string[] args)
        {
            string[] tmp = { "fiwdwd56 wsq77  ", "55  44  33" };

            Converter converter = new Converter();

            ConvertRule convertRule1 = RemoveDigits;
            Console.WriteLine(converter.Convert(tmp[0], convertRule1));
            Console.WriteLine(converter.Convert(tmp[1], convertRule1));

            ConvertRule convertRule2 = RemoveSpaces;
            Console.WriteLine(converter.Convert(tmp[0], convertRule2));
            Console.WriteLine(converter.Convert(tmp[1], convertRule2));

            ConvertRule convertRule = RemoveDigits;
            convertRule += RemoveSpaces;

            Console.WriteLine(converter.Convert(tmp[0], convertRule));
            Console.WriteLine(converter.Convert(tmp[1], convertRule));



        }
    }
}
