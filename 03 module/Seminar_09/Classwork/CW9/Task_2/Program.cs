using System;
using System.IO;

//В первом проекте, создать бинарный файл Numbers и записать в него средствами класса
//BinaryWriter 10 целых чисел, случайно выбранных из интервала [1;100].


//Во втором проекте вывести на экран числа из файла Numbers, а затем заменять в  этом файле
//на введенное пользователем целое значение число, ближайшее по значению к тому, которое ввел пользователь,
//и вновь выводить числа из файла на экран. Вводимые числа, не принадлежащие интервалу [1;100],  игнорировать.

namespace Task_2
{
    class Program
    {
        static void Main(string[] args)
        {
            CreateFile();

            ReadFile();
                
            Console.WriteLine("Введите число");
            int number = int.Parse(Console.ReadLine());

            using (FileStream f = new FileStream("../../../t.dat", FileMode.Open))
            using (BinaryReader fIn = new BinaryReader(f))
            using (BinaryWriter fOut = new BinaryWriter(f))
            {
                long n = f.Length / 4; int a;
                int[] numbers = new int[n];

                for (int i = 0; i < n; i++)
                {
                    numbers[i] = fIn.ReadInt32();
                }

                // поиск ближайшего числа.
                int nearest = 0;
                GetNearest(number, numbers, ref nearest);

                f.Position = 0;
                for (int i = 0; i < n; i++)
                {
                    if (fIn.ReadInt32() == nearest)
                    {
                        f.Position -= 4;
                        fOut.Write(number);
                    }
                }

            }

            ReadFile();
        }

        private static void ReadFile()
        {
            using (FileStream f = new FileStream("../../../t.dat", FileMode.Open))
            using (BinaryReader fIn = new BinaryReader(f))
            {
                Console.WriteLine("\nЧисла из файла:");

                long n = f.Length / 4; int a;
                for (int i = 0; i < n; i++)
                {
                    a = fIn.ReadInt32();
                    Console.Write(a + " ");
                }
            }
        }

        private static void CreateFile()
        {
            using (BinaryWriter fOut = new BinaryWriter(new FileStream("../../../t.dat", FileMode.Create)))
            {
                Random random = new Random();

                for (int i = 0; i <= 10; i++)
                    fOut.Write(random.Next(1, 101));
            }
        }

        private static void GetNearest(int number, int[] numbers, ref int nearest)
        {
            int minDelta = int.MaxValue;
            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] - number < minDelta)
                    nearest = numbers[i];
            }
        }
    }
}
