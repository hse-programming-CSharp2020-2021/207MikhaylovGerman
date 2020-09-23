using System;

namespace Task_03
{
    class Program
    {
        static void Main(string[] args)
        {
            double y = Console.ReadLine();
            double z = Console.ReadLine();
            double x = Console.ReadLine();
            double tmp;
            if (y > z)
            {   z = tmp;
                z = y;
                y = tmp;
            }
            if (x > y)
            {
                x = tmp;
                x = y;
                y = tmp;
            }
             

        }
    }
}
