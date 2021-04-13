using System;

namespace Task_3
{
    public class Program
    {
        static void Main(string[] args)
        {
            Processing.WriteFile("equation.xml", 8);
            Console.WriteLine("Выполнена запись в режиме сериализации.");
            Console.WriteLine("Для вывода на экран нажмите любую клавишу.");
            Console.ReadKey(true);
            Console.WriteLine("В файле сведения о следующих уравнениях: ");

            // Обращение с использованием делегата:
            Processing.Process("equation.xml", new Qdelegate(Processing.PrintEq));
            Console.WriteLine("Для решения уравнений нажмите любую клавишу.");
            Console.ReadKey(true);
            Console.WriteLine("\r\nРешения уравнений с вещественными корнями: ");
            Processing.Process("equation.xml", new Qdelegate(Processing.SolutionReal));
            Console.WriteLine("Для завершения работы нажмите ENTER.");
            Console.ReadLine();

        }
    }
}
