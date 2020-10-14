using System;
using System.IO;
using System.Linq;
using System.Threading;

namespace Task_4
{
    class Program
    {
        private static string[] inputFile;

        /// <summary>
        /// Метод считывает весь текст с файла.
        /// </summary>
        /// <param name="inputPath"></param>
        /// <returns></returns>
        private static string[] GetTextFromFile(string inputPath)
        {
            try
            {
                inputFile = File.ReadAllText(inputPath).Split(' ');
            }
            catch (Exception)
            {
                Console.WriteLine("Файла, из которого следует прочитать строки, не существует!");
            }

            return inputFile;
        }

        /// <summary>
        ///  Метод задает массив из булевских значений.
        /// </summary>
        /// <param name="Input"></param>
        /// <param name="PathOutput"></param>
        private static void GetBoolArray(string PathOutput)
        {
            int[] A = new int[inputFile.GetLength(0)];
            bool[] L = new bool[inputFile.GetLength(0)];

            int number = 0;
            // Перекладываем данные из массива string[] в int[].
            for (int i = 0; i < inputFile.Length; i++)
            {
                try
                {
                    if (int.TryParse(inputFile[i], out number) && A[i] >= -10 && A[i] <= 10)
                    {
                        A[i] = number;
                    }

                }
                catch (Exception)
                {
                    Console.WriteLine("Неверный формат входныз данных");
                }

            }

            for (int i = 0; i < A.Length; i++)
            {
                if (A[i] > 0)
                {
                    L[i] = true;
                }
                else
                {
                    L[i] = false;
                }
                // Записываем в файл.
                File.AppendAllText(PathOutput, L[i].ToString() + " ");
            }




        }

        static void Main(string[] args)
        {
            string pathtoInputFile = "input.txt";
            string pathtoOutputFile = "output.txt";

            // Получаем строки из файла.
            inputFile = GetTextFromFile(pathtoInputFile);
            // Если данные в массиве < 0, то меняем на False. Если данные в массиве > 0, то меняем на True.
            GetBoolArray(pathtoOutputFile);

        }
    }

}
