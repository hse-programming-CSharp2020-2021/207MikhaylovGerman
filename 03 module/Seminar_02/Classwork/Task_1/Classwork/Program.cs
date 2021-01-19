using System;

namespace Classwork
{
    class Plant
    {
        private double growth;
        private double photosensitivity;
        private double frostresistance;

        public double Growth
        {
            get
            {
                return growth;
            }
            set
            {
                growth = value;
            }
        }

        public double Photosensitivity
        {
            get => photosensitivity;
            set
            {
                if (value <= 100 && value > 0)
                    photosensitivity = value;
                else
                {
                    throw new Exception();
                }
            }
        }

        public double Frostresistance
        {
            get => frostresistance;
            set
            {
                if (value <= 100 && value > 0)
                    frostresistance = value;
            }
        }

        public override string ToString() => $"Рост: {growth}, Светочувствительность: {photosensitivity}, Морозоустойчивость: {frostresistance}";


        public Plant(double growth, double photosensitivity, double frostresistance)
        {
            Growth = growth;
            Photosensitivity = photosensitivity;
            Frostresistance = frostresistance;
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите число:");
            string input = Console.ReadLine();
            int n = int.Parse(input);

            Plant[] plants= new Plant[n];

            Random random = new Random();
            for (int i = 0; i < plants.Length; i++)
            {
                plants[i] = new Plant(random.Next(25, 100), random.Next(0, 100), random.Next(0, 80));
            }

            Array.ForEach(plants, a => Console.WriteLine(a));
            Console.WriteLine();

            Array.Sort(plants, (x, y) => y.Growth.CompareTo(x.Growth));
            Array.ForEach(plants, a => Console.WriteLine(a));
            Console.WriteLine();

            Array.Sort(plants, (x, y) => x.Frostresistance.CompareTo(y.Frostresistance));
            Array.ForEach(plants, a => Console.WriteLine(a));
            Console.WriteLine();

            Array.Sort(plants, (x, y) => {
                if (x.Photosensitivity % 2 == 0 && y.Photosensitivity % 2 != 0)
                    return 1;
                else
                    return -1;
            });
            Array.ForEach(plants, a => Console.WriteLine(a));
            Console.WriteLine();
        }
    }
}
