using System;

namespace Homework
{
    class Polygon
    {
        // Количество сторон многоугольника.
        int N;
        // Радиус вписанной окружности.
        double _r;
        // Конструктор по умолчанию.
        public Polygon()
        {
            N = 4;
            _r = 2.0;
        }
        public Polygon(int N, double _r)
        {
            this.N = N;
            this._r = _r;
        }
        // Свойство Periment.
        private double Perimetr
        {
            get
            {
                double term = Math.Tan(Math.PI / N);
                return 2 * term * _r * N;
            }
        }
        // Свойство Suare.
        private double Square
        {
            get
            {
                return _r / 2 * Perimetr;
            }
        }
        // Общедоступный метод.
        public string PolygonData()
        {
            return string.Format($"N = {N}, R = {_r}, P = {Perimetr}, S = {Square} .");
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            Polygon polygon = new Polygon();
            Console.WriteLine("По умолчанию создан многоугольник: ");
            Console.WriteLine(polygon.PolygonData());

            int N;
            double R;
            while (!int.TryParse(Console.ReadLine(), out N) || !double.TryParse(Console.ReadLine(), out R) || R < 0.0 || N < 1)
            {
                Console.WriteLine("Incorrect input");
            }

            polygon = new Polygon(N, R);
            Console.WriteLine($"Свойства: {polygon.PolygonData()}");
             
        }
    }
}
