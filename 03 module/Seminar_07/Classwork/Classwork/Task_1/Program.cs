using System;
using System.IO;
using System.Text;

namespace Task_1
{
    class Program
    {
        static void Main(string[] args)
        {
            using (FileStream fs = new FileStream("input.txt", FileMode.OpenOrCreate))
            {
                if (fs.CanRead)
                {
                    byte[] text = new byte[fs.Length];
                    fs.Read(text, 0, (int)fs.Length);

                    string str = Encoding.Default.GetString(text);
                    Console.WriteLine(str);

                    for (int i = 0; i < text.Length; i++)
                    {   
                        if (text[i] >= '0' && text[i] <= '9')
                            Console.WriteLine(text);
                    }
                }
            }
        }
    }
}
