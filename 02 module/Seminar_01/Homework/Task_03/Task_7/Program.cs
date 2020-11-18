using System;

namespace Task_7
{
    class Program
    {
        static string[] Filials = { "Западный", "Центральный", "Восточный" };
        static string[] Kvartal = { "I", "II", "III", "IV" };
        static int[,] auto = { { 20, 24, 25 },
                { 21, 20, 18 },
                { 23, 27, 24 },
                { 22, 19, 20 } };

        static void Main(string[] args)
        {
            string s, input;
            // Печать исходных данных.
            Console.Write(PrintSrc());
            do
            {
                // Вывод текстового меню.
                Console.Write(Print());
                // Обработка выбранного пункта меню + вывод результата .                      
                s = PrintResults(input = Console.ReadLine());
                Console.WriteLine(s);

            } while (input != "0");
            Console.ReadLine();

        }

        /// <summary>
        /// все результаты
        /// </summary>
        /// <returns>строка, сформированная по результатам работы методов</returns>
        public static string PrintResults(string mode)
        {
            string st = "";

            int lineNumber;
            int columnNumber;
            int NFiliala_MaxAutoYear;
            int MaxAutoFilialZaGod;
            int NKvartal_MaxAuto;
            int MaxAutoKvartal;

            switch (mode)
            {
                case "0":
                    st += "Спасибо за работу!\r\n";
                    break;
                case "1":
                    st += "Ответ 1. Общее количество автомобилей = " +
                    GrandTotal() + "\r\n";
                    break;
                case "2":
                    GetMax4Kvartal(out lineNumber, out columnNumber);
                    st += "Ответ 2. Mаксимальное количество автомобилей = " +
                       auto[lineNumber, columnNumber] + ", Квартал = " + Kvartal[lineNumber] + ", Филиал = " + Filials[columnNumber] + "\r\n";
                    break;
                case "3":
                    maxAutoFilialZaGod(out NFiliala_MaxAutoYear, out MaxAutoFilialZaGod);
                    st += "Ответ 3. Название филиала, который продал максимальное количество автомобилей по результатам года = " +
                           Filials[NFiliala_MaxAutoYear] +
                           ", проданное количество автомобилей = " + MaxAutoFilialZaGod + "\r\n";
                    break;
                case "4":
                    maxAutoKvartal(out NKvartal_MaxAuto, out MaxAutoKvartal);
                    st += "Ответ 4. Наиболее успешный квартал = " + Kvartal[NKvartal_MaxAuto] + ", проданное количество автомобилей = " + MaxAutoKvartal + "\r\n"; break;
                default:
                    st += "Неизвестный режим. Введите число [0..4]\r\n";
                    break;
            }
            return st;
        }

        /// <summary>
        /// вывод массива
        /// </summary>
        /// <returns></returns>
        private static string PrintSrc()
        {
            string st = "Исходные данные:\r\n\\\t";
            foreach (var item in Filials)
            {
                st += item + "\t";
            }
            st += "\r\n";
            for (int i = 0; i < auto.GetLength(0); i++)
            {
                st += Kvartal[i] + "\t";
                for (int j = 0; j < auto.GetLength(1); j++)
                    st += auto[i, j] + "\t\t";
                st += "\r\n";
            }
            return st;
        }

        /// <summary>вывод меню </summary>
        private static string Print()
        {
            return @"Выберите, что вы желаете сделать:
     1. Вычислить общее количество автомобилей;
     2. Вывести максимальное количество автомобилей, проданных филиалом за квартал (название филиала и номер квартала);
     3. Найти название филиала, который продал максимальное количество    автомобилей по результатам года (и число проданных);
     4. Найти наиболее успешный квартал (номер квартала и число проданных);
     0. Завершить работу.
     Ваш выбор: ";
        }

        /// <summary>
        /// 1) Подсчитать общее количество автомобилей, проданных всеми филиалами компании за год.
        /// </summary>
        /// <returns>общее количество автомобилей</returns>
        private static int GrandTotal()
        {
            int total = 0;
            for (int i = 0; i < auto.GetLength(0); i++)
                for (int k = 0; k < auto.GetLength(1); k++)
                    total += auto[i, k];

            return total;
        }
        /// <summary>
        /// 2) Вывести максимальное количество автомобилей, проданных филиалом за квартал, а также название филиала и номер квартала.
        /// </summary>
        /// <param name="Nstroki"></param>
        /// <param name="Nstolbca"></param>
        private static void GetMax4Kvartal(out int Nstroki, out int Nstolbca)
        {
            Nstroki = 0;
            Nstolbca = 0;
            for (int i = 0; i < auto.GetLength(0); i++)
                for (int j = 0; j < auto.GetLength(1); j++)
                    if (auto[Nstroki, Nstolbca] < auto[i, j])
                    {
                        Nstroki = i;
                        Nstolbca = j;
                    }
        }

        /// <summary>
        /// 3) Вывести название филиала, который продал максимальное количество автомобилей по результатам года, а также их количество
        /// </summary>
        /// <param name="NFiliala_MaxAutoYear"></param>
        /// <param name="MaxAutoFilialZaGod"></param>
        private static void maxAutoFilialZaGod(out int NFiliala_MaxAutoYear, out int MaxAutoFilialZaGod)
        {

            int region1 = 0;
            for (int k = 0; k < auto.GetLength(1); k++)
            {
                region1 += auto[0, k];
            }
            int region2 = 0;
            for (int k = 0; k < auto.GetLength(1); k++)
            {
                region1 += auto[1, k];
            }
            int region3 = 0;
            for (int k = 0; k < auto.GetLength(1); k++)
            {
                region1 += auto[2, k];
            }
            MaxAutoFilialZaGod = 0;
            if (region1 >= region2)
            {
                if (region1 >= region3)
                {
                    MaxAutoFilialZaGod = region1;
                    NFiliala_MaxAutoYear = 0;
                }
                else
                {
                    MaxAutoFilialZaGod = region3;
                    NFiliala_MaxAutoYear = 2;
                }
            }
            else
            {
                if (region2 >= region3)
                {
                    MaxAutoFilialZaGod = region2;
                    NFiliala_MaxAutoYear = 1;
                }
                else
                {
                    NFiliala_MaxAutoYear = 2;
                    MaxAutoFilialZaGod = region3;
                }
            }

        }

        /// <summary>
        /// 4) Вывести наиболее успешный квартал, в котором компания показала наилучший результат по продажам(учитываются все филиалы), 
        /// а также количество автомобилей проданное в нем.
        /// </summary>
        /// <param name="NKvartal_MaxAuto"></param>
        /// <param name="MaxAutoKvartal"></param>
        private static void maxAutoKvartal(out int NKvartal_MaxAuto, out int MaxAutoKvartal)
        {
            MaxAutoKvartal = 0;
            NKvartal_MaxAuto = 0;
            for (int i = 0; i < auto.GetLength(0); i++)
            {
                int cache = 0;
                for (int k = 0; k < auto.GetLength(1); k++)
                {
                    cache += auto[i, k];
                }
                if (cache > MaxAutoKvartal)
                {
                    MaxAutoKvartal = cache;
                    NKvartal_MaxAuto = i;
                }
            }
            

        }
    }
}