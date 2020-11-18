using System;

namespace Task_9
{
    class LinearEquation
    {
        int A { get; set; }
        int B { get; set; }
        int C { get; set; }

        internal int GetA() => A;
        internal int GetB() => B;
        internal int GetC() => C;

        public double GetResult()
        {
            var result = (double)(C - B) / A;
            return result;
        }


        public LinearEquation(int a, int b, int c)
        {
            A = a;
            B = b;
            C = c;
        }
        

    }


    class Program
    {
        static void Main(string[] args)
        {
            do
            {
                int N;
                do
                {
                    Console.WriteLine("Введите N") ;
                } while (!int.TryParse(Console.ReadLine(), out N));

                LinearEquation[] linearEquation = new LinearEquation[N];

                // Печать несортированного массива.
                Console.WriteLine("Неотсортированные решения: " + Environment.NewLine);
                for (int i = 0; i < linearEquation.Length; i++)
                {
                    Random random = new Random();
                    linearEquation[i] = new LinearEquation(random.Next(-10, 10), random.Next(-10, 10), random.Next(-10, 10));
                    Console.WriteLine($"A:{linearEquation[i].GetA()}, B:{linearEquation[i].GetB()}, C:{linearEquation[i].GetC()}, Result: {linearEquation[i].GetResult()}");

                }
                // Сортировка пузырьком.
                for (int i = 0; i < linearEquation.Length - 1; i++)
                {
                    for (int k = 0; k < linearEquation.Length - 1; k++)
                    {
                        if (linearEquation[i].GetResult() > linearEquation[i + 1].GetResult())
                        {
                            LinearEquation tmp = linearEquation[i];
                            linearEquation[i] = linearEquation[i + 1];
                            linearEquation[i + 1] = tmp;
                        }
                    }
                }

                Console.WriteLine("Отсортированные решения: " + Environment.NewLine);
                for (int i = 0; i < linearEquation.Length; i++)
                    Console.WriteLine($"A:{linearEquation[i].GetA()}, B:{linearEquation[1].GetB()}, C:{linearEquation[i].GetC()}, Result: {linearEquation[i].GetResult()}");



                Console.WriteLine("Для выхода нажмите ESC, для продолжения Enter...");
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }
    }
}
