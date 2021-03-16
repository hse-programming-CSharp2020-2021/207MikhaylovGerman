using System;
using System.Collections.Generic;
using System.IO;

class ColorPoint
{
    public static string[] colors = { "Red", "Green", "DarkRed", "Magenta", "DarkSeaGreen",
        "Lime", "Purple", "DarkGreen", "DarkOrange", "Black", "BlueViolet", "Crimson", "Gray", "Brown", "CadetBlue" };
    public double x, y;
    public string color;
    public override string ToString()
    {
        string format = "{0:F3}    {1:F3}    {2}";
        return string.Format(format, x, y, color);
    }
}

class Test
{
    static Random gen = new Random();
    public static void Main()
    {
        string path = @"..\..\..\..\MyTest.dat";
        int N = 10;

        List<ColorPoint> list = new List<ColorPoint>();
        ColorPoint one;
        for (int i = 0; i < N; i++)
        {
            one = new ColorPoint();
            one.x = gen.NextDouble();
            one.y = gen.NextDouble();
            int j = gen.Next(0, ColorPoint.colors.Length);
            one.color = ColorPoint.colors[j];
            list.Add(one);
        }

        // Запись массива стpок в бинарный файл файл:
        var fs = new FileStream(path, FileMode.Open);
        using (BinaryWriter bw = new BinaryWriter(fs))
        {
            foreach (var obj in list)
            {
                bw.Write(obj.color);
                bw.Write(obj.x);
                bw.Write(obj.y);
            }
        }

        Console.WriteLine("Записаны {0} строк в бинарный файл: \n{1}",
                                                                      N, path);
    }
} // class Test


