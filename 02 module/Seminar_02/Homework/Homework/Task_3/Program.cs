using System;
using System.Linq;

// Класс многоугольников.
public class Polygon
{ 
    int numb;
    // Радиус вписанной окружности.
    double radius;

    public Polygon(int n = 3, double r = 1)
    {      
        numb = n;
        radius = r;
    }

    /// <summary>
    /// Периметр многоугольника - свойство.
    /// </summary>
    public double Perimeter => 2 * numb * radius * Math.Tan(Math.PI / numb);
    
    public double Area => Perimeter * radius / 2;
    
    public string PolygonData()
    {
        string res = string.Format("N={0}; R={1}; P={2,2:F3}; S={3,4:F3}",
        numb, radius, Perimeter, Area);
        return res;
    }
}

public class Program
{
    public static void Main()
    {
        Polygon polygon = new Polygon();
        Console.WriteLine("По умолчанию создан многоугольник: ");
        Console.WriteLine(polygon.PolygonData());

        do
        {
            int N;
            do Console.Write("Введите число сторон: ");
            while (!int.TryParse(Console.ReadLine(), out N) | N < 0);

            Polygon[] polygons = new Polygon[N];
            for (int i = 0; i < polygons.Length; i++)
            {
                double rad;
                int number;

                do Console.Write("Введите число сторон: ");
                while (!int.TryParse(Console.ReadLine(), out number) | number < 3);

                do Console.Write("Введите радиус: ");
                while (!double.TryParse(Console.ReadLine(), out rad) | rad < 0);

                polygons[i] = new Polygon(number, rad);
                
            }

            int indexmax;
            double max = double.MinValue;
            double min = double.MaxValue;
            int indexmin;
            for (int i = 0; i < polygons.Length; i++)
            {
                if (polygons[i].Area > max)
                {
                    max = polygons[i].Area;
                    indexmax = i;
                }
                if (polygons[i].Area < min)
                {
                    min = polygons[i].Area;
                    indexmin = i;
                }
            }

            foreach (var item in polygons)
            {
                if (item.Area == min)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Сведения о многоугольнике:");
                    Console.WriteLine(item.PolygonData());
                    Console.ResetColor();
                }
                else if (item.Area == max)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Сведения о многоугольнике:");
                    Console.WriteLine(item.PolygonData());
                    Console.ResetColor();
                }
                else
                {
                    Console.WriteLine("Сведения о многоугольнике:");
                    Console.WriteLine(item.PolygonData());
                }
            }


            Console.WriteLine("Для выхода нажмите клавишу ESC");
        } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        
        

           

    }
}
