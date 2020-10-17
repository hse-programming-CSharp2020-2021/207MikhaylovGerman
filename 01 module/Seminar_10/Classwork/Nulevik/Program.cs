using System;
using System.Linq;

namespace Nulevik
{
    class Program
    {
        /// <summary>
        /// Метод возвращает массив простых чисели их количество.
        /// </summary>
        /// <param name="sequence"></param>
        /// <returns></returns>
        private static int[] Primes(int[] sequence, out int counter)
        {
            counter = 0;
            // Массив простых чисел.
            int[] PrimeNumbers = new int[1];
            int dev;
            bool flag;
            for (int i = 0; i < sequence.Length; i++)
            {
                flag = true;
                dev = 1;

                while (dev < sequence[i])
                {
                    if (sequence[i] % dev == 0)
                    {
                        // Число не простое.
                        flag = false;
                    }
                    dev++;
                }

                if (flag)
                {
                    Array.Resize(ref PrimeNumbers, counter + 1);
                    PrimeNumbers[counter] = sequence[i];
                    counter++;

                }
            }


            return PrimeNumbers;
        }
        /// <summary>
        /// Метод возвращает bool значение убывающая ли последовательность.
        /// </summary>
        /// <returns></returns>
        private static bool IsNotDecreasing(int[] sequence, out int min)
        {
            min = sequence.Min();
            // true - неубывающая последовательность.
            bool flag = true;
            for (int i = 0; i < sequence.Length - 1; i++)
            {
                if (sequence[i + 1] < sequence[i])
                {
                    flag = false;
                }
            }

            return flag;
        }
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
                Random random = new Random();
                int[] sequence = new int[N];
                for (int i = 0; i < N; i++)
                {
                    sequence[i] = random.Next(0, 10);
                }

                int counter;
                int[] PrimeNumbers = Primes(sequence, out counter);
                Console.WriteLine($"Количество простых чисел в массиве = {counter}");
                Console.WriteLine("Массив простых чисел ");
                foreach (var number in PrimeNumbers)
                {
                    Console.Write(number + " ");
                }
                Console.WriteLine();
                int min;
                bool IsNitdecreasing = IsNotDecreasing(sequence, out min);
                if (IsNitdecreasing)
                {
                    Console.WriteLine("Последовательность неубывающая");
                }
                else
                {
                    Console.WriteLine("Последовательность не является неубывающей");
                }

                Console.WriteLine($"Минимум последовательности = {min}");

                Console.WriteLine("Для выхода нажмите ESC ");
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
            
        }
    }
}
