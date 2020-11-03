using System;

namespace Task_5
{
    class Function
    {
        double xmin;
        double xmax;
        double delta;
        public Function(double xmin, double xmax, double delta)
        {
            this.xmin = xmin;
            this.xmax = xmax;
            this.delta = delta;
        }

        public double this[double x]
        {
            get
            {
                if (x >= xmin && x <= xmax)
                    return Math.Sin(x);
                else
                    return 0;
            }

        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            double xmin = 0;
            double delta = Math.PI / 6;
            double xmax = Math.PI;
            for (double i = xmin; i < xmax; i += delta)
            {
                Function function = new Function(xmin, xmax, delta);
                Console.WriteLine($"Sin = {function[i]}");
            }
        }
    }
}
