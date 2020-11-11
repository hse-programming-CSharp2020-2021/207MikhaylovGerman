using System;

namespace Task_8
{
    class Point
    {
        double x;
        double y;

        public double GetX()
        {
            return x;
        }
        public double GetY()
        {
            return y;
        }

        public double X
        {
            get
            {
                return x;
            }
            set
            {
                x = value;
            }
        }
        public double Y
        {
            get
            {
                return y;
            }
            set
            {
                y = value;
            }
        }
        public Point() { }

        public Point(double x, double y)
        {
            this.x = x;
            this.y = y;
        }
        public double GetLength(double x1, double y1, double x2, double y2)
        {
            return Math.Sqrt(Math.Pow(x1 - x2, 2) + Math.Pow(y1 - y2, 2));
        }
    }

    class Triangle
    {

        private readonly Point a;
        private readonly Point b;
        private readonly Point c;

        private double AB
        {
            get
            {
                return GetLengthOfSide(a, b);
            }
        }
        private double AC
        {
            get
            {
                return GetLengthOfSide(a, c);
            }
        }
        private double BC
        {
            get
            {
                return GetLengthOfSide(b, c);
            }
        }

        public Triangle() { }

        public Triangle(Point a, Point b, Point c)
        {
            this.a = a;
            this.b = b;
            this.c = c;
        }
        public Triangle(double x1, double x2, double x3, double y1, double y2, double y3)
        {
            a = new Point(x1, y1);
            b = new Point(x2, y2);
            c = new Point(x3, y3);
        }


        public double GetPerimeter()
        {
            return AB + AC + BC;
        }

        public double GetSquare()
        {
            double semiPerimetr = this.GetPerimeter() / 2;
            return Math.Sqrt(semiPerimetr * (semiPerimetr - AB) * (semiPerimetr - AC) * (semiPerimetr - BC));
        }

        private static double GetLengthOfSide(Point a, Point b)
        {
            double x = Math.Abs(a.GetX() - b.GetX());
            double y = Math.Abs(a.GetY() - b.GetY());
            var result = Math.Sqrt(x * x + y * y);
            return result;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            do
            {
                Random random = new Random();
                int N = random.Next(5, 15);

                Triangle[] triangles = new Triangle[N];
                Point[] points = new Point[N * 3];
                double[] squares = new double[N];

                int currentPointer = 0;
                for (int i = 0; i < triangles.Length; i++)
                {
                    // Создание 3 точек.
                    for (int k = 0; k < 3; k++)
                        points[currentPointer++] = new Point(random.Next(-10, 10), random.Next(-10, 10));

                    // Создание треугольника.
                    triangles[i] = new Triangle(points[currentPointer - 3], points[currentPointer - 2], points[currentPointer - 1]);

                    squares[i] = triangles[i].GetSquare();
                    Console.WriteLine($"Triangles {i} : perimeter = {triangles[i].GetPerimeter():F3}, square = {squares[i]:F3}, вершины треугольника: a = ({points[currentPointer - 3].GetX()},{points[currentPointer - 3].GetY()}), b = ({points[currentPointer - 2].GetX()},{points[currentPointer - 2].GetY()}), c = ({points[currentPointer - 1].GetX()},{points[currentPointer - 1].GetY()}). ");
                }
                // Сортировка массива треугольников.
                for (int k = 0; k < triangles.Length - 1; k++)
                    for (int i = 0; i < squares.Length - 1; i++)
                    {
                        if (squares[i] < squares[i + 1])
                        {
                            double tmpSquares = squares[i];
                            squares[i] = squares[i + 1];
                            squares[i + 1] = tmpSquares;

                            Triangle tmpTriangles = triangles[i];
                            triangles[i] = triangles[i + 1];
                            triangles[i + 1] = tmpTriangles;
                        }
                    }

                Console.WriteLine("Массив после сортировки по убыванию площади: ");
                for (int i = 0; i < triangles.Length; i++)
                    Console.WriteLine($"Triangles {i} : perimeter = {triangles[i].GetPerimeter():F3}, square = {squares[i]:F3}. ");

                Console.WriteLine(" ДЛя выхода нажмите ESC, для повторения решения ESC...");
            } while (Console.ReadKey(true).Key != ConsoleKey.Enter);
        }
    }
}
