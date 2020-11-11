﻿using System;

namespace classwork
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
            Point point1 = new Point(x1, y1);
            Point point2 = new Point(x2, y2);
            Point point3 = new Point(x3, y3);
            a = point1;
            b = point2;
            c = point3;

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
}

