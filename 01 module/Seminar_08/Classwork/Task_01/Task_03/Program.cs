using System;
using System.IO;
using System.Text;

namespace ConsoleApp23
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"Data.txt";

            // Создаем файл с данными
            if (File.Exists(path))
            {
                // Сейчас данные для записи вбиты в коде
                // TODO1: сохранить в файл целые случайные значения из диапазона [10;100)

                Random random = new Random();
                string str1 = "";
                for (int i = 0; i < 5; i++)
                {
                    str1 += random.Next(10, 100).ToString();
                }

                string str2 = "";
                for (int i = 0; i < 5; i++)
                {
                    str2 += random.Next(10, 100).ToString();
                }

                string createText = str1 + Environment.NewLine +
                    str2;
                File.WriteAllText(path, createText, Encoding.UTF8);
            }

            // Open the file to read from
            if (File.Exists(path))
            {
                string readText = File.ReadAllText(path);
                string[] stringValues = readText.Split(' ');
                int[] arr = StringArrayToIntArray(stringValues);
                int[] arrayEven = new int[arr.Length];
                int[] arrayOdd = new int[arr.Length];
                int EvenCounter = 0;
                int OddCounter = 0;
                for (int i  = 0; i < arr.Length; i++)
                {
                    if (arr[i] % 2 == 0)
                    {
                        arrayEven[EvenCounter++] = i;
                    }
                    else
                    {
                        arrayOdd[OddCounter++] = i;
                        arr[i] = 0;
                    }
                }
                foreach (var item in arrayEven)
                {
                    Console.Write(item + " ");
                }
                Console.WriteLine();
                foreach (var item in arrayOdd)
                {
                    Console.Write(item + " ");
                }
                Console.WriteLine();
                foreach (var item in arr)
                {
                    Console.Write(item + " ");
                }
                Console.WriteLine();

                // обрабатываем элементы массива
                // TODO2: Создать два массива по исходному
                // в первый поместить индексы чётных элементов, во второй - нечётных
                // TODO3: Заменяем все нечётные числа исходного массива нулями
            }
        } // end of Main()
        // преобразование массива строк в массив целых чисел
        public static int[] StringArrayToIntArray(string[] str)
        {
            int[] arr = null;
            if (str.Length != 0)
            {
                arr = new int[0];
                foreach (string s in str)
                {
                    int tmp;
                    if (int.TryParse(s, out tmp))
                    {
                        Array.Resize(ref arr, arr.Length + 1);
                        arr[arr.Length - 1] = tmp;
                    }
                } // end of foreach (string s in str)      
            }
            return arr;
        } // end of StringToIntArray()
    } // end of Program
}
