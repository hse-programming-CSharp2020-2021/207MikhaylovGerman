using System;

namespace CW_1
{
    class MainClass
    {
        delegate int Cast(double param);

        delegate string d1(int number);
        delegate string d2(int number);

        public static void Main(string[] args)
        {
            Cast cast = delegate (double input)
            {
                return (int)input;
	        };
            Cast cast1 = x => x.ToString().Length;

            double test = 5.4926411;
            double test1 = 4.31;

            Console.WriteLine(cast(test));
            Console.WriteLine(cast1(test));

            Console.WriteLine(cast(test1));
            Console.WriteLine(cast1(test1));

            var multicastcast = cast;
            multicastcast += cast1;
            Console.WriteLine(multicastcast(test));

            d1 d1 = x => x.ToString();
            d2 d2 = x => x.ToString();

            int number = 10;
            Console.WriteLine(d1(number));
            Console.WriteLine(d2(number));

        }
    }
}
