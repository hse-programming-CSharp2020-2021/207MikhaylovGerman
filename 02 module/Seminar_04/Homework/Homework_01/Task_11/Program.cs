using System;

namespace Task_11
{
    class GeometricProgression
    {
        double _start;
        double _increment;

        public GeometricProgression()
        {
            _start = 0;
            _increment = 1;
        }

        public GeometricProgression(double start, double increment)
        {
            _start = start;
            _increment = increment;
        }
        // Свойства, сокращенный до выражений.
        public double this[int index] => _start + (index - 1) * _increment;

        public string GetInfo() => $"Start: {_start}, Increment: {_increment}";

        public double GetSum(int n) => (2 * _start + (n - 1) * _increment) * n / 2;

    }

    class Program
    {
        static void Main(string[] args)
        {
            do
            {
                GeometricProgression progression = new GeometricProgression();

                Random random = new Random();

                var N = random.Next(5, 15);
                // Создаем массив прогрессий.
                GeometricProgression[] geometricProgressions = new GeometricProgression[N];

                for (int i = 0; i < geometricProgressions.Length; i++)
                    geometricProgressions[i] = new GeometricProgression(random.NextDouble() * 10, random.NextDouble() * 5);

                Console.WriteLine("Весь массив: ");
                for (int i = 0; i < geometricProgressions.Length; i++)
                    Console.WriteLine(geometricProgressions[i].GetInfo());

                var step = random.Next(3, 15);
                Console.WriteLine($"Прогрессии, которые превосходят в элементе с индексом step: {step} базовую прогрессию.");
                // Сравниваем step- ый элемент последовательностей.
                for (int i = 0; i < geometricProgressions.Length; i++)
                    if (geometricProgressions[i][step] > progression[step])
                        Console.WriteLine(geometricProgressions[i].GetInfo());

               
                Console.WriteLine("Для выхода нажмите ESC, для продолжения Enter...");
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }
    }
}
