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
            string text = File.ReadAllText(inputPath);

            try
            {
                inputFile = text.Split(new char[] { ' ' });
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
        /// <param name="input"></param>
        /// <param name="pathOutput"></param>
        private static void GetBoolArray(string pathOutput)
        {
            int[] A = new int[inputFile.GetLength(0)];
            int[] B = new int[inputFile.GetLength(0)];

            string str = String.Empty;

            int number = 0;
            // Перекладываем данные из массива string[] в int[].
            for (int i = 0; i < inputFile.Length; i++)
            {
                try
                {
                    if (int.TryParse(inputFile[i], out number) && A[i] >= 0 && A[i] <= 10000)
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
                B[i] = GetNearest(A[i]);

                // Записываем в файл.
                File.AppendAllText(pathOutput, Convert.ToString(B[i]) + " ");
            }




        }
        /// <summary>
        /// Метод находит ближайшее число(степень двойки).
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        private static int GetNearest(int number)
        {
            // 2 в 0-ой степени.
            int result = 0;
            while (result < number)
            {
                result *= 2;
            }
            if (result > number)
            {
                result /= 2;
            }

            return result;
        }

        static void Main(string[] args)
        {
            do
            {   
                string pathtoinputFile = "input.txt";
                string pathtoOutputFile = "output.txt";
                // Получаем строки из файла.
                inputFile = GetTextFromFile(pathtoinputFile);
                // Выводим массив ближайших степеней двойки в файл.
                GetBoolArray(pathtoOutputFile);

                Console.WriteLine("Для выхода нажмите ESC...");
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
            

        }
    }

}
