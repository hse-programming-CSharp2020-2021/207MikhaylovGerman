using System;

namespace Task_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Birthday md = new Birthday("Чапаев", 1887, 2, 9);
            Console.WriteLine(md.Information);
            Console.WriteLine("До следующего дня рождения дней осталось: ");
            Console.WriteLine(md.HowManyDays);

            Birthday km = new Birthday("Маркс Карл", 1818, 5, 4);
            Console.WriteLine(km.Information);
            Console.WriteLine("До следующего дня рождения дней осталось: ");
            Console.WriteLine(km.HowManyDays);

            Birthday km2 = new Birthday("Маркс Карл", 1818, 5, 4);
            Console.WriteLine(km.Information);
            Console.WriteLine(km.Information2);
            Console.WriteLine(km.Information3);
        }
    }

    class Birthday
    {
        string name;
        // Закрытые поля: год, месяц, день рождения.
        int year, month, day;

        public Birthday(string name, int y, int m, int d)
        { 
            this.name = name;
            year = y; month = m; day = d;
        }

        public Birthday()
        {
            day = 1; month = 1;
            year = 1970;
        }

        DateTime Date => new DateTime(year, month, day);
        
        public string Information => name + ", дата рождения " + day + ":" + month + ":" + year;

        public string Information2 => "Дата рождения " + day + "-" + month + "-" + year;

        public string Information3 => Date.ToString();

        /// <summary>
        /// Cвойство - сколько дней до дня рождения.
        /// </summary>
        public int HowManyDays
        { 
            get
            {
                int nowDOY = DateTime.Now.DayOfYear;
                int myDOY = Date.DayOfYear;
                int period = myDOY >= nowDOY ? myDOY - nowDOY :
                                               365 - nowDOY + myDOY;
                return period;
            }
        }
    }

}

