using System;

namespace Task_1
{
    class Matrix
    {
        private double a11;
        private double a12;
        private double a21;
        private double a22;

        public Matrix(double a11, double a12, double a21, double a22)
        {
            this.a11 = a11;
            this.a12 = a12;
            this.a21 = a21;
            this.a22 = a22;

        }

        public Matrix(double a11, double a22)
        {
            this.a11 = a11;
            this.a12 = .0;
            this.a21 = .0;
            this.a22 = a22;

        }

        public Matrix(Matrix matrix)
        {
            this.a11 = matrix.a11;
            this.a12 = matrix.a12; ;
            this.a21 = matrix.a21; ;
            this.a22 = matrix.a22; ;
        }

        public double Det()
        {
            return a11 * a22 - a12 * a21;
        }

        public Matrix Inverse()
        {
            if (Det() == 0)
                throw new ArgumentException("непорядок");

            double newA11 = (1 / Det()) * a22;
            double newA12 = (1 / Det()) * -a12;
            double newA21 = (1 / Det()) * -a21;
            double newA22 = (1 / Det()) * -a11;

            return new Matrix(newA11, newA12, newA21, newA22);
        }

        public Matrix Transpose()
        {
            return new Matrix(a11, a21, a12, a22);
        }

        public static Matrix operator +(Matrix a, Matrix b)
        {
            return new Matrix(a.a11 + b.a11, a.a12 + b.a12, a.a21 + b.a21, a.a22 + b.a22);
        }

        public static Matrix operator *(Matrix a, Matrix b)
        {
            return new Matrix(a.a11 * b.a11 + a.a12 * b.a21, a.a11 * b.a21 + a.a12 * b.a22, a.a21 * b.a11 + a.a22 * b.a12, a.a21 * b.a21 + a.a22 * b.a22);
        }

        public static Matrix operator *(int constant, Matrix a)
        {
            return new Matrix(constant * a.a11, constant * a.a12, constant * a.a21, constant * a.a22);
        }

        public static Matrix operator /(Matrix a, int constant)
        {
            if (constant == 0)
                throw new ArgumentException("непорядок");
            return new Matrix(a.a11 / constant, a.a12 / constant, a.a21 / constant, a.a22 / constant);
        }

        public override string ToString()
        {
            return $"{a11}\t{a12}{Environment.NewLine}{a21}\t{a22}";
        }

        public static bool operator true(Matrix matrix)
        {
            return matrix.Det() > 0;
        }

        public static bool operator false(Matrix matrix)
        {
            return matrix.Det() == 0;
        }

        public static explicit operator double(Matrix matrix)
        {
            return matrix.Det();
        }

    }   
    class Program
    {
        static void Main(string[] args)
        {
            Matrix a, b;
            a = new Matrix(1.0, 5, 4, 2);
            b = new Matrix(5, 4);

            Console.WriteLine(a + b);
            Console.WriteLine(a * b);
            Console.WriteLine(2 * b);
            Console.WriteLine(b / 2);
            Console.WriteLine(a.Transpose());
            Console.WriteLine(b.Det());

        }
    }
}
