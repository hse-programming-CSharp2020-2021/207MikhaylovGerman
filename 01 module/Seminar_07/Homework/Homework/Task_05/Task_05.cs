using System;

namespace Task_05
{
    class MainClass
    {

        private static void Main(string[] args)
        {
            int N;
            do
            {
                Console.WriteLine("Введите  N");
            } while (!int.TryParse(Console.ReadLine(), out N));

            int[,] Array1 = new int[N, N];
            // 1.
            Console.WriteLine(" 1 картинка: ");
            FillArray1(Array1);
            // 2.
            Console.WriteLine(" 2 картинка: ");
            FillArray2(Array1);
            // 3.
            Console.WriteLine(" 3 картинка: ");
            FillArray3(Array1);
            // 4.
            Console.WriteLine(" 4 картинка: ");
            FillArray4(Array1);

        }

        /// <summary>
        /// Метод заполняет массив числами(картинка 1).
        /// </summary>
        /// <param name="Array"></param>
        private static void FillArray1(int[,] Array1)
        {
            Random random = new Random();
            for (int i = 0; i < Array1.GetLength(0); i++)
            {
                for (int k = 0; k < Array1.GetLength(1); k++)
                {
                    if (k < Array1.GetLength(0) / 2 && k <= i && i + k < Array1.GetLength(0) - 1)
                    {
                        Array1[i, k] = random.Next(0, 25);
                    }

                }
            }
            Print(Array1);
        }

        /// <summary>
        /// Метод печатает массив на экран.
        /// </summary>
        /// <param name="Array1"></param>
        private static void Print(int[,] Array1)
        {
            Console.WriteLine();
            for (int i = 0; i < Array1.GetLength(0); i++, Console.WriteLine())
            {
                for (int k = 0; k < Array1.GetLength(1); k++)
                {
                    Console.Write(Array1[i, k] + "\t");
                }

            }
        }

        /// <summary>
        /// Метод заполняет массив числами(картинка 2).
        /// </summary>
        /// <param name="Array"></param>
        private static void FillArray2(int[,] Array1)
        {
            Random random = new Random();
            for (int i = 0; i < Array1.GetLength(0); i++)
            {
                for (int k = 0; k < Array1.GetLength(1); k++)
                {
                    if (i > k && i + k > Array1.GetLength(0))
                    {
                        Array1[i, k] = random.Next(0, 25);
                    }

                }
            }
            Print(Array1);
        }

        /// <summary>
        /// Метод заполняет массив числами(картинка 3).
        /// </summary>
        /// <param name="Array"></param>
        private static void FillArray3(int[,] Array1)
        {
            Random random = new Random();
            for (int i = 0; i < Array1.GetLength(0); i++)
            {
                for (int k = 0; k < Array1.GetLength(1); k++)
                {
                    if (i < Array1.GetLength(0) / 3 && k > i && i + k < Array1.GetLength(0))
                    {
                        Array1[i, k] = random.Next(0, 25);
                    }
                    else if (i > 2 * Array1.GetLength(0) / 3 && i > k && i + k > Array1.GetLength(0))
                    {
                        Array1[i, k] = random.Next(0, 25);
                    }

                }
            }
            Print(Array1);
        }

        /// <summary>
        /// Метод заполняет массив числами(картинка 4).
        /// </summary>
        /// <param name="Array"></param>
        private static void FillArray4(int[,] Array1)
        {
            Random random = new Random();
            for (int i = 0; i < Array1.GetLength(0); i++)
            {
                for (int k = 0; k < Array1.GetLength(1); k++)
                {
                    if (k < Array1.GetLength(0) / 2 && i < Array1.GetLength(0) / 3 && k > i && i + k < Array1.GetLength(0))
                    {
                        Array1[i, k] = random.Next(0, 25);
                    }
                    else if (k > Array1.GetLength(0) / 2 && i > 2 * Array1.GetLength(0) / 3 && i > k && i + k > Array1.GetLength(0))
                    {
                        Array1[i, k] = random.Next(0, 25);
                    }

                }
            }
            Print(Array1);
        }
    }
}
