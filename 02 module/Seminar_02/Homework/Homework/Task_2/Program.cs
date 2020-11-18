using System;

namespace Task_2
{
    class Point
    {
        public double X { get; set; }
        public double Y { get; set; }
        public Point(double x, double y) { X = x; Y = y; }
        // Конструктор умолчания.
        public Point() : this(0, 0) { } 
                                              
        public string PointData
        {   
            get
            {
                string maket = "X = {0:F2}; Y = {1:F2}; Ro = {2:F2}; Fi = {3:F2} ";
                return string.Format(maket, X, Y, Ro, Fi);
            }
        }
        /// <summary>
        /// Свойтво расстояния до наала координат.
        /// </summary>
        public double Ro => Math.Sqrt(Math.Pow(X, 2) + Math.Pow(Y, 2));

        /// <summary>
        /// Свойство Fi. 
        /// </summary>
        public double Fi
        {
            get
            {
                if (X > 0 & Y >= 0)
                {
                    return Math.Atan(Y / X);
                }
                else if (X > 0 & Y < 0)
                {
                    return Math.Atan(Y / X) + 2 * Math.PI;
                }
                else if (X < 0)
                {
                    return Math.Atan(Y / X) + Math.PI;
                }
                else
                {
                    // X == 0.
                    if (Y > 0)
                    {
                        return Math.PI / 2;
                    }
                    else if (Y < 0)
                    {
                        return 3 * Math.PI / 2;
                    }
                    else
                    {
                        return 0;
                    }
                }

            }
        }

       
    }

    class Program
    {

        static void Main()
        {
            Point a, b, c;
            a = new Point(3, 4);
            Console.WriteLine(a.PointData);
            b = new Point(0, 3);
            Console.WriteLine(b.PointData);
            c = new Point();
            double x = 0, y = 0;
            do
            {
                Console.Write("x = ");
                double.TryParse(Console.ReadLine(), out x);
                Console.Write("y = ");
                double.TryParse(Console.ReadLine(), out y);
                c.X = x; c.Y = y;
                double max;

                Point[] points = new Point[3];
                points[0] = a;
                points[1] = b;
                points[2] = c;

                for (int i = 0; i < points.Length - 1; i++)
                    for (int k = 0; k < points.Length - 1; k++)
                        if (points[i].Ro > points[i + 1].Ro)
                            points[i + 1] = points[i];

                foreach (var point in points)
                    Console.WriteLine($"Ro: {point.Ro}, X: {point.X}, Y: {point.Y} ");

            } while (x != 0 | y != 0);
        }




    }
}
