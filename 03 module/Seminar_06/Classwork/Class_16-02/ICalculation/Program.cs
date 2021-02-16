using System;

namespace ICalculation
{
    interface ICalculation
    {
        double Perform(double input);
    }
    class Add : ICalculation
    {
        double add;
        public Add(double add)
        {
            this.add = add;
        }

        public double Perform(double input)
        {
            return input + add;
        }
    }

    class Multiply : ICalculation
    {
        double coeff;
        public Multiply(double coeff)
        {
            this.coeff = coeff;
        }

        public double Perform(double input)
        {
            return input * coeff;
        }
    }
    class Program
    {
        private static double Calculate(double input, ICalculation p1, ICalculation p2)
        {
            return p2.Perform(p1.Perform(input));
        }

        static void Main(string[] args)
        {
            var x = Calculate(12, new Add(2), new Multiply(2));
        }
    }
}
