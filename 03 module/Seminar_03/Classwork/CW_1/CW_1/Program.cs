using System;

namespace CW_1
{
    public delegate void SquareSizeChanged(double param);

    class Square
    {
        public event SquareSizeChanged OnSizeChanged;

        private double leftTopCornerX;
        private double rightBottomCornerX;
        private double leftTopCornerY;
        private double rightBottomCornerY;

        public double LeftTopCornerX
        {
            get
            {
                return leftTopCornerX;
            }
            set
            {
                OnSizeChanged?.Invoke(value);
                leftTopCornerX = value;
            }
        }

        public double RightBottomCornerX
        {
            get
            {
                return rightBottomCornerX;
            }
            set
            {
                OnSizeChanged?.Invoke(value);
                rightBottomCornerX = value;
            }
        }
        public double LeftTopCornerY
        {
            get
            {
                return leftTopCornerY;
            }
            set
            {
                OnSizeChanged?.Invoke(value);
                leftTopCornerY = value;
            }
        }

        public double RightBottomCornerY
        {
            get
            {
                return rightBottomCornerY;
            }
            set
            {
                OnSizeChanged?.Invoke(value);
                rightBottomCornerY = value;
            }
        }


        public Square(double leftTopCornerX, double leftTopCornerY, double rightBottomCornerX, double rightBottomCornerY)
        {
            LeftTopCornerX = leftTopCornerX;
            RightBottomCornerX = rightBottomCornerX;
            LeftTopCornerY = leftTopCornerY;
            RightBottomCornerY = rightBottomCornerY;
        }

    }
    class Program
    {
        private static void SquareConsoleInfo(double side)
        {
            Console.WriteLine($"Side: {side:F2}");
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Вершина 1: X = ");
            double x1 = double.Parse(Console.ReadLine());
            Console.WriteLine("Вершина 1: Y = ");
            double y1 = double.Parse(Console.ReadLine());
            Console.WriteLine("Вершина 2: X = ");
            double x2 = double.Parse(Console.ReadLine());
            Console.WriteLine("Вершина 2: Y = ");
            double y2 = double.Parse(Console.ReadLine());

            Square s = new Square(x1, y1, x2, y2);
            s.OnSizeChanged += SquareConsoleInfo;

            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("Вершина 1: X = ");
                s.LeftTopCornerX = double.Parse(Console.ReadLine());
                Console.WriteLine("Вершина 1: Y = ");
                s.LeftTopCornerY = double.Parse(Console.ReadLine());
                Console.WriteLine("Вершина 2: X = ");
                s.RightBottomCornerX = double.Parse(Console.ReadLine());
                Console.WriteLine("Вершина 2: Y = ");
                s.RightBottomCornerY= double.Parse(Console.ReadLine());

            }

        }
    }
}
