using System;

namespace Task_4
{

    public class HexNumber
    {   // представление неотрицательных целых
        uint number;
        // Шестнадцатеричное представление.
        // целое неотрицательное число 
        char[] hexView;
        public HexNumber(uint n)
        { // конструктор общего вида
            number = n;
            hexView = Series(n);
        }
        public HexNumber() : this(0) { }


        public uint Number
        {   // Свойство: десятичное целое
            get { return number; }
            set
            {
                number = value;
                hexView = Series(value);
            }
        }
        public char[] HexView => hexView;

        public string Record => "0x" + new String(hexView);

        // Возвращает массив шестнадцатеричных цифр числа-параметра. 
        char[] Series(uint num)
        {
            int arLen = num == 0 ? 1 : (int)Math.Log(num, 16) + 1;
            char[] res = new char[arLen];
            for (int i = arLen - 1; i >= 0; i--)
            {
                uint temp = (uint)(num % 16);
                if (temp >= 0 & temp <= 9) res[i] = (char)('0' + temp);
                else res[i] = (char)('A' + temp % 10);
                num /= 16;
            }
            return res;
        }   

    }

    class Program
    {
        public static void Main()
        {
            HexNumber hex;     
            hex = new HexNumber(0); 
            uint number;

            while (true)
            {   // Цикл для ввода разных значений числа.
                do
                {
                    Console.Write("Введите целое неотрицательное число:  ");
                } while (!uint.TryParse(Console.ReadLine(), out number));

                // Изменяем объект через свойство.
                hex.Number = number;     
                Console.WriteLine("Свойство Number: " + hex.Number);
                Console.Write("Шестнадцатеричные цифры числа: ");

                foreach (char h in hex.HexView)
                    Console.Write("{0} ", h);

                Console.WriteLine($"{Environment.NewLine}Шестнадцатеричная запись: " + hex.Record);
                Console.WriteLine("Для выхода нажмите клавишу ESC");

                if (Console.ReadKey(true).Key == ConsoleKey.Escape)
                    break;
            }    

        }


    }
}
