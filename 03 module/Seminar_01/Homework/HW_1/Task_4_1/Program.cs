using System;

namespace Task_4
{
    class Robot
    {
        // Положение робота на плоскости.
        int x, y;

        public void Right()
        {
            x++;
        }
        public void Left()
        {
            x--;
        }
        public void Forward()
        {
            y++;
        }
        public void Backward()
        {
            y--;
        }

        public string Position() => String.Format("The Robot position: x={0}, y={1}", x, y);
        public string Pos() => String.Format("x = {0}, y = {1}", x, y);

    }



    class Program
    {
        delegate void Steps();

        static void Main(string[] args)
        {
            do
            {
                Version_1();

                Version_2();

                Console.WriteLine(" Для выхода нажмите ESC...");
            } while (Console.ReadKey().Key != ConsoleKey.Escape);

        }

        private static void Version_2()
        {
            Robot rob1 = new Robot();
            Steps delR = new Steps(rob1.Right);
            Steps delL = new Steps(rob1.Left);
            Steps delF = new Steps(rob1.Forward);
            Steps delB = new Steps(rob1.Backward);

            // Шаги по диагоналям (многоадресные делегаты):
            Steps delRF = delR + delF;
            Steps delRB = delR + delB;
            Steps delLF = delL + delF;
            Steps delLB = delL + delB;

            delLB();
            Console.WriteLine(rob1.Position());

            delRB();
            Console.WriteLine(rob1.Position());
        }

        private static void Version_1()
        {
            Robot rob = new Robot();
            Steps[] trace = { new Steps(rob.Backward),
                           new Steps(rob.Backward),
                           new Steps(rob.Left)
            };
            Console.WriteLine("Start:" + rob.Position());

            for (int i = 0; i < trace.Length; i++)
            {
                Console.WriteLine($"Method={trace[i].Method}, Target={trace[i].Target}");
                trace[i]();
            }

            Console.WriteLine(rob.Position());
        }

    }
}

