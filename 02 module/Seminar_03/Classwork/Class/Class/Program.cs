using System;



namespace Application
{
    class ArProgression
    {
        int a0;
        int d;



        public int A0
        {
            get
            {
                return a0;
            }
            set
            {
                a0 = value;
            }
        }



        public int D
        {
            get
            {
                return d;
            }
            set
            {
                d = value;
            }
        }



        public ArProgression(int a0, int d)
        {
            A0 = a0;
            D = d;
        }



        public int this[int index]
        {
            get
            {
                if (index < 0)
                    throw new ArgumentException("Index should be >= 0");
                return a0 + d * index;
            }
        }
    }



    class MainClass
    {
        public static void Main(string[] args)
        {
            ArProgression arProgression = new ArProgression(2, 3); // 2, 5, 8, 11...
            Console.WriteLine(arProgression[0]);
            Console.WriteLine(arProgression[1]);
            Console.WriteLine(arProgression[2]);
            Console.WriteLine(arProgression[3]);
        }
    }
}