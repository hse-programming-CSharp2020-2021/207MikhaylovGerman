using System;

namespace Task_1
{
    interface IFigure
    {
        double Square();
    }

    class Rectangular : IFigure
    {
        private double side;

        public Rectangular(double side)
        {
            this.side = side;
        }
        public double Square()
        {
            return side * side;
        }
        public override string ToString()
        {
            return $"Фигура: {this}, площадь: {Square()}";

        }
    }

    class Circle : IFigure
    {
        private double radius;

        public Circle(double radius)
        {
            this.radius = radius;
        }
        public double Square()
        {
            return Math.PI * radius * radius;
        }
        public override string ToString()
        {
            return $"Фигура: {this}, площадь: {Square()}";
        }
    }
    class Program
    {
        public static void Info<T>(T[] figures, double treshhold) where T : IFigure
        {
            foreach (var item in figures)
            {
                if (item.Square() > treshhold)
                    Console.WriteLine($"Фигура: {item}, площадь: {item.Square()}");
            }
        }

        static void Main(string[] args)
        {
            double threshold = 20;

            IFigure[] figures = { new Rectangular(20), new Circle(100), new Rectangular(1), new Circle(0) };

            foreach (var item in figures)
            {
                item.ToString();
            }

            Info<IFigure>(figures, threshold);

        }
    }
}
