using System;

namespace Task_05
{
    class Program
    {
        /// <summary>
        /// Метод дублирует значение Y в массиве, если она встретилось.
        /// </summary>
        /// <param name="array"></param>
        /// <param name=""></param>
        private static void ArrayItemDouble(ref int[] array,int Y)
        {
            // counter количество элементов в массиве, совпадающих с Y. 
            int counter = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == Y)
                {
                    counter++;
                }
            }

            if (counter != 0)
            {
                // удлиненние массива.
                Array.Resize(ref array, array.Length + counter);

                for (int i = 0; i < array.Length; i++)
                {
                    if (array[i] == Y)
                    {
                        // сдвиг всех элементов массива, чтобы освободить место под дубликацию.
                        // counter тепер выступает в роли параметра: на сколько элементов сдвигать и когда останавливаться.
                        for (int k = array.Length - 1; k > i + (counter - 1); k--)
                        {
                            array[k - (counter - 1)] = array[k - counter];
                        }
                        // уменьшение параметра, после завершения одного дублирования.
                        counter--;
                        i++;
                    }
                }

            }
            else
            {
                Console.WriteLine("В массиве не нашлось элементов, эквивалентных Y");
            }
            


        }

        private static void Main(string[] args)
        {
            Console.WriteLine("Введите  N, а затем Y ");
            int N;
            while (!int.TryParse(Console.ReadLine(), out N))
            {
                Console.WriteLine("Incorrect input");
            }
            Console.WriteLine("Введите Y");
            int Y;
            while (!int.TryParse(Console.ReadLine(), out Y))
            {
                Console.WriteLine("Incorrect input");
            }

            int[] array = new int[N];
            FillRandomArray(ref array);

            ArrayItemDouble(ref array, Y);

            PrintArray(ref array);
        }

        /// <summary>
        /// Метод печатает элементы на экран.
        /// </summary>
        private static void PrintArray(ref int[] array)
        {
            Array.ForEach(array, x => Console.Write(x + " "));
        }

        /// <summary>
        /// Метод заполняет массив random числами от MinValue до MaxValue.
        /// </summary>
        private static void FillRandomArray(ref int[] array)
        {
            Random random = new Random();
            int MinValue = 10;
            int MaxValue = 100;
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = random.Next(MinValue, MaxValue);
            }
        }
    }
}
