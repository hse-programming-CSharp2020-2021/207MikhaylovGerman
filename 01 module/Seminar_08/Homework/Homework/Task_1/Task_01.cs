using System;
using System.IO; // Пространство имён System.IO -> File.
using System.Text; // Кодировка.

class Program
{
    static Random rand = new Random();
    static void Main()
    {
        // основные настрйки
        const string fileName = "dialog.txt";
        Encoding enc = Encoding.Unicode;
        // кол-во предложений.
        const int linesCount = 6;   

        // Создаем файл на диске 
        File.WriteAllText(fileName, string.Empty, enc);
        // Создаём пустой файл.
        Console.WriteLine("Переписка до форматирования:");
        for (int i = 0; i < linesCount; i++)
        {
            // предложение.
            string message = string.Empty;
            // Длина сообщения от 20 до 50 символов (51 - 50 включён в диапазон).
            int length = rand.Next(20, 51); 
            for (int j = 0; j < length; j++)
            {
                // Посимвольное добавление букв в сообщение. "Ё" нет в диапазоне от А до Я!.
                message += (char)rand.Next('А', 'Я'); 
            }
            // Добавляем в сообщение точку и перенос на следующую строку.
            message += "." + Environment.NewLine;
            // Добавляем строку в файл.
            File.AppendAllText(fileName, message, enc); 
            Console.Write(message);
        }

        // читаем сформированный файл и обрабатываем предложения.
        // Массив сообщений из переписки.
        string[] messages = File.ReadAllLines(fileName, enc); 
        Console.WriteLine(Environment.NewLine + "Переписка после форматирования:");
        foreach (string item in messages)
            // Выводим сообщения из переписки без точек на экран.
            Console.WriteLine(item.Substring(0, item.Length - 1)); 
    }
}