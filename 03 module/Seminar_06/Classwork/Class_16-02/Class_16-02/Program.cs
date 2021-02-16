using System;
using System.Collections.Generic;



namespace Task_3
{
    namespace A
    {
        public abstract class Figure
        {
            public int A { get; set; }
        }



        interface ISquare
        {
            double Square();
        }
        interface IPrint
        {
            void Print();
        }
        interface IVolume
        {
            double Volume();
        }
        interface I2D : IPrint, ISquare { }
        class Triangle : Figure, ISquare, IPrint
        {
            public void Print()
            {
                Console.WriteLine($"{A} -> {Square():f2}");
            }


            public double Square()
            {
                return A * A * Math.Sqrt(3) / 4;
            }
        }



        class Cube : Figure, ISquare, IPrint, IVolume
        {
            public void Print()
            {
                Console.WriteLine($"{A} -> {Square():f2} -> {Volume():f2}");
            }


            public double Square()
            {
                return A * A * 6;
            }


            public double Volume()
            {
                return A * A * A;
            }
        }


        class MainClass
        {
            public static void Main()
            {
                int n = 10;
                Figure[] figures = new Figure[n];
                // IPrint[] figures = new IPrint[n];
                Random random = new Random();


                for (int i = 0; i < n; i++)
                {
                    int t = random.Next(0, 2);
                    if (t == 0)
                        figures[i] = new Triangle() { A = random.Next(1, 10) };
                    else
                        figures[i] = new Cube() { A = random.Next(1, 10) };
                    //(figures[i] as IPrint).Print();
                    if (figures[i] is IVolume)
                        (figures[i] as IPrint).Print();
                }

            }
        }
    }
}