
using System;
using System.Linq;

namespace Nulevik
{
    class Program
    {
        
        static void Main(string[] args)
        {
            do
            {
                int N;
                do
                {
                    Console.WriteLine("Введите N (количество чисел в последовательности)");
                } while (!int.TryParse(Console.ReadLine(), out N));
                // Заполнение массива.
                double[] X, Y;
                Random(N, out X, out Y);

                double[] Xin, Yin, Xout, Yout;
                IsItLocatedIn(N, X, Y, out Xin, out Yin, out Xout, out Yout);

                Console.WriteLine($" X и Y, которые вошли в область ");

                for (int i = 0; i < Xin.Length; i++)
                {
                    Console.WriteLine($"{Xin[i]} , {Yin[i]}");
                }
                Console.WriteLine($" X и Y, которые не вошли в область ");
                for (int i = 0; i < Xout.Length; i++)
                {
                    Console.WriteLine($"{Xout[i]} , {Yout[i]}");
                }



                Console.WriteLine("Для выхода нажмите ESC ");
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);

        }

        private static void IsItLocatedIn(int N, double[] X, double[] Y, out double[] Xin, out double[] Yin, out double[] Xout, out double[] Yout)
        {
            Xin = new double[1];
            Yin = new double[1];
            Xout = new double[1];
            Yout = new double[1];
            int counter1 = 0;
            int counter2 = 0;

            for (int i = 0; i < N; i++)
            {
                if (Math.Sqrt(Math.Pow(X[i], 2) + Math.Pow(Y[i], 2)) < 4.0 && Math.Sqrt(Math.Pow(X[i], 2) + Math.Pow(Y[i], 2)) > 2.0)
                {
                    Array.Resize(ref Xin, counter1 + 1);
                    Xin[counter1++] = X[i];
                    Array.Resize(ref Yin, counter1 + 1);
                    Yin[counter1++] = Y[i];
                }
                else
                {
                    Array.Resize(ref Xout, counter2 + 1);
                    Xout[counter2++] = X[i];
                    Array.Resize(ref Yout, counter2 + 1);
                    Yout[counter2++] = Y[i];
                }
            }
        }

        private static void Random(int N, out double[] X, out double[] Y)
        {
            Random random = new Random();
            X = new double[N];
            Y = new double[N];
            int cache = 0;
            for (int i = 0; i < N; i++)
            {
                cache = random.Next(-4, 4);
                if (cache < 0)
                {
                    X[i] = cache - random.NextDouble();
                    Y[i] = cache - random.NextDouble();
                }
                else
                {
                    X[i] = cache + random.NextDouble();
                    Y[i] = cache + random.NextDouble();
                }

            }
        }
    }
}
