using System;
using System.Linq;

namespace DoubleArr
{
    class Circle
    {
        double _r;
        public double Radius
        {
            get
            {
                return _r;
            }
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Radius should be non-negative");
                _r = value;
            }
        }

        public double S
        {
            get
            {
                return Math.PI * _r * _r;
            }
        }
        public double Length
        {
            get
            {
                return Radius * Math.PI * 2;
            }

        }

        public Circle()
        {
            Radius = 1;
        }

        public Circle(double radius)
        {
            Radius = radius;
        }

        public override string ToString()
        {
            return $"Circle: radius = {Radius:f3}, Square = {S:f3}";
        }
    }

    /*
     * этап 2
     * Свойство подсчета длины окружности. 
     * Ввести значение n.
     * Генерируем массив из кругов со случайным значением радиуса (Rmin, Rmax)
     * Для всех кругов считаем площадь и длину окружности и вывести на экран.
     * Найти круг с наибольшей площадью и вывести его на экран.
*/

    class Program
    {
        static void Main(string[] args)
        {
            double rmin = double.Parse(Console.ReadLine());
            double rmax = int.Parse(Console.ReadLine());
            double delta = double.Parse(Console.ReadLine());

            Circle circle;

            for (double i = rmin; i <= rmax; i += delta)
            {
                circle = new Circle(i);
                Console.WriteLine(circle.ToString());
            }

            Console.WriteLine("Введите количество кругов");
            int n = int.Parse(Console.ReadLine()); 
           
            double[] rings = new double[n];
            Random random = new Random();
            double max = double.MinValue;
            for (int i = 0; i < n; i++)
            {
                rings[i] = random.Next((int)rmin, (int)rmax);
                circle = new Circle(rings[i]);
                Console.WriteLine("Площадь ");
                double res = circle.S;
                if (res > max)
                {
                    max = res;
                }
                Console.WriteLine(res);
                Console.WriteLine("Длина окружности ");
                Console.WriteLine(circle.Length);

            }
            Console.WriteLine("Круг с максимальной площадью ");
            Console.WriteLine(max);
        }
    }
}
