using System;

namespace Switch
{
    class Program
    {
        public static void Converter(out int mark)
        {   
            switch (mark)
            {
                case 1:
                case 2:
                case 3:
                    Console.WriteLine("неудовлетворительно");
                    break;
                case 4:
                case 5:
                    Console.WriteLine("уд");
                    break;
                case 6:
                case 7:
                    Console.WriteLine("good");
                    break;
                case 8:
                case 9:
                case 10:
                    Console.WriteLine("ex");
                    break;

            }
        }
        static void Main(string[] args)
        {
            do
            {
                Console.WriteLine("Введите оценку");
                int mark;
                // проверка ввода 
                while (!int.TryParse(Console.ReadLine(), out mark))
                {
                    Console.WriteLine("Ошибка ввода ");
                    Console.WriteLine("Введите оценку");
                }
                Program.Converter(out mark);
               




                Console.WriteLine("Нажмите ESC для выхода ");
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }
    }
}
