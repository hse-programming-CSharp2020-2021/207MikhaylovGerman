using System;

namespace Task_3
{
    public class Quadratic
    {
        public int Discriminant { get; set; }
        public double X1 { get; set; }
        public double X2 { get; set; }

        public Quadratic(int A, int B, int C)
        {
            if (A == 0)
                throw new ArgumentException("Невырожденное уравнение");
            Discriminant = B * B - 4 * A * C;

            SolveEq(A, B);
        }

        public Quadratic()
        {
        }

        private void SolveEq(int a, int b)
        {
            if (Discriminant == 0)
            {
                X1 = (double)-b / 2 * a;
            }
            else if (Discriminant > 0)
            {
                X1 = (-b + Math.Sqrt(Discriminant)) / 2 * a;
                X2 = (-b - Math.Sqrt(Discriminant)) / 2 * a;
            }

        }
    }
}