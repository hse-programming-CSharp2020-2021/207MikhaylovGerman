using System;
using System.IO;
using System.Linq;


partial class Program
{
    /// <summary>
    /// Метод считывает весь текст с файла.
    /// </summary>
    /// <param name="inputPath"></param>
    /// <returns></returns>
    private static string GetTextFromFile(string inputPath)
    {
        // Считываем все в одну строку.
        try
        {
            string inputFile = File.ReadAllText(inputPath);
        }
        catch (Exception)
        {
            Console.WriteLine("Файла, из которого следует прочитать строки, не существует!");
        }

        return inputPath;

    }
    /// <summary>
    /// Метод вычленияет цифры из строки.
    /// </summary>
    /// <param name="text"></param>
    /// <returns></returns>
    private static int[] GetNumbersFromText(string text)
    {
        // Массив разделителей.
        char[] splitters = {';'};

        //  Создаем массив строк, разделенных по разделителям.
        string[] strings = text.Split(splitters);

        int numbertoConvert = 0;
        int[] numbers = null;
        int pointer = 0;
        // Пробегаем по строкам.
        foreach (var substring in strings)
        {
            if (substring != "" && !Array.Exists(splitters, i => i == substring[0]))
            {
                if (int.TryParse(substring, out numbertoConvert))
                {
                    Array.Resize(ref numbers, pointer + 1);
                    numbers[pointer++] += numbertoConvert;
                }
            }

        }

        return numbers;

    }
    /// <summary>
    /// Метод печатает массив на экран и average значение.
    /// </summary>
    /// <param name="numbers"></param>
    private static void Printresult(int[] numbers)
    {
        Array.ForEach(numbers, i => Console.Write(String.Concat(i, " ")));

        Console.WriteLine();

        Console.WriteLine(String.Concat("Среднее значение = ", numbers.Average()));
    }

}

partial class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.txt";
        string text = GetTextFromFile(inputPath);

        Console.WriteLine(GetNumbersFromText(text));
    }


}
