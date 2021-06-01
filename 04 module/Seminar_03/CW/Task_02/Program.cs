using System;

namespace Task_02
{
    class Program
    {
        static void Main(string[] args)
        {
            Butter butter = new Butter(20);
            Bread bread = new Bread(15);

            Sandwich sandwich = bread + butter;
        }
    }

    class Bread
    {
        public int Weight { get; set; } // масса

        public Bread(int weight)
        {
            Weight = weight;
        }
    }

    class Butter
    {
        public int Weight { get; set; } // масса

        public Butter(int weight)
        {
            Weight = weight;
        }

        public static Sandwich operator +(Bread bread, Butter butter)
        {
            return new Sandwich(bread.Weight + butter.Weight);
        }
    }

    class Sandwich
    {
        public int Weight { get; set; } // масса

        public Sandwich(int weight)
        {
            Weight = weight;
        }
    }
}
