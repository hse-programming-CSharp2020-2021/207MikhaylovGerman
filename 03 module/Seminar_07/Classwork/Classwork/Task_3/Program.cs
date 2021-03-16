using System;
using System.IO;
using System.Text;

namespace Task_3
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = new int[10];
            Random rd = new Random();

            for(int i = 0; i < 10; i++)
                numbers[i] = rd.Next();

            string path1 = "../../Output1.txt";
            string path2 = "../../Output2.txt";
            string path3 = "../../Output3.txt";
            string path4 = "../../Output4.txt";

            string output = Array.ConvertAll(numbers, x => x.ToString()).ToString();

            File.WriteAllText(path1, output);

            using (FileStream fs = new FileStream(path2, FileMode.OpenOrCreate))
            {
                byte[] stringBytes = Encoding.Default.GetBytes(output);
                fs.Write(stringBytes);
            }

            using (StreamWriter sw = new StreamWriter(File.Open(path3, FileMode.OpenOrCreate)))
            {
                sw.Write(output);
            }

            using (BinaryWriter bw = new BinaryWriter(new FileStream(path4, FileMode.OpenOrCreate)))
            {
                bw.Write(output);
            }

            using (StreamReader sr = new StreamReader(new FileStream(path1, FileMode.Open))) { Console.WriteLine(sr); }
            using (StreamReader sr = new StreamReader(new FileStream(path2, FileMode.Open))) { Console.WriteLine(sr); }
            using (StreamReader sr = new StreamReader(new FileStream(path3, FileMode.Open))) { Console.WriteLine(sr); }
            using (StreamReader sr = new StreamReader(new FileStream(path4, FileMode.Open))) { Console.WriteLine(sr); }

            using (StreamReader sr = new StreamReader(new FileStream(path1, FileMode.Open)))
            {
                int sum = 0;

                string text = String.Empty;
                do
                {
                    text = sr.ReadLine();
                    foreach (var smbl in text)
                    {
                        int number;
                        if (int.TryParse(smbl.ToString(), out number) && number % 2 == 0)
                            sum += number;
                    }

                } while (text != null);

                Console.WriteLine(sum);
                
            }

        }
    }
}
