using System;

namespace ISequence
{
    interface ISequence
    {
        double Getelement(int index);
    }

    class ArithmeticProgression : ISequence
    {
        double first;
        double step;
        public ArithmeticProgression(double first, double step)
        {
            this.first = first;
            this.step = step;
        }
        public double Getelement(int index)
        {
            return first + step * (index - 1);
        }
    }

    class GeomentricProgression : ISequence
    {
        double first;
        double diff;
        public GeomentricProgression(double first, double diff)
        {
            this.first = first;
            this.diff = diff;
        }
        public double Getelement(int index)
        {
            return first * Math.Pow(diff, index - 1);
        }
    }

    class Program
    {
        public static double Sum(ISequence sequence , int count)
        {
            double sum = 0;
            for (int i = 0; i < count; i++)
                sum += sequence.Getelement(i);
            return sum;
        }

        static void Main(string[] args)
        {
            var s1 = Sum(new ArithmeticProgression(2, 10), 10);
            var s2 = Sum(new GeomentricProgression(2, 10), 10);
        }
    }
}
