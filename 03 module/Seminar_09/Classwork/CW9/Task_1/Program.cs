using System;
using System.IO;
class Program
{
    static void Main()
    {
        using (BinaryWriter fOut = new BinaryWriter(new FileStream("../../../t.dat", FileMode.Create)))
        {
            for (int i = 0; i <= 10; i += 2)
                fOut.Write(i);
        }

        // 1) TODO: Прочитать и напечатать все числа из файла в обратном порядке

        using (FileStream f = new FileStream("../../../t.dat", FileMode.Open))
        using (BinaryReader fIn = new BinaryReader(f))
        {
            Console.WriteLine("\nЧисла в обратном порядке:");

            long n = f.Length / 4; int a;
            f.Position = f.Length - 4;
            for (int i = 0; i < n; i++)
            {
                a = fIn.ReadInt32();
                if (f.Position >= 8)
                    f.Position -= 8;
                else
                    f.Position = 0;
                Console.Write(a + " ");
            }
        }

        Console.WriteLine();

        // 2) TODO: увеличить  все числа в файле в 5 раз
        using (FileStream f = new FileStream("../../../t.dat", FileMode.Open))
        using (BinaryReader fIn = new BinaryReader(f))
        using (BinaryWriter fOut = new BinaryWriter(f))
        {
            long n = f.Length / 4; int a;
            for (int i = 0; i < n; i++)
            {
                a = 5 * fIn.ReadInt32();
                f.Position -= 4;
                fOut.Write(a);
            }
        }

        // 3) TODO: Прочитать и напечатать все числа из файла в прямом порядке
        using (FileStream f = new FileStream("../../../t.dat", FileMode.Open))
        using (BinaryReader fIn = new BinaryReader(f))
        {
            Console.WriteLine("\nЧисла в прямом порядке:");

            long n = f.Length / 4; int a;
            for (int i = 0; i < n; i++)
            {
                a = fIn.ReadInt32();
                Console.Write(a + " ");
            }
        }

    }
}