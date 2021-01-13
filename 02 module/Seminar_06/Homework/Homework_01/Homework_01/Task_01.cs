using System;

namespace Homework_01
{
    class A
    {
        public virtual void getA()
        {
            Console.Write("A");
        }
    }
    class B : A
    {
        public override void getA()
        {
            Console.Write("B");
        }
    }

    class Program
    {
        static void Main()
        {
            A[] arr = new A[10];
            Random ran = new Random();
            for (int k = 0; k < arr.Length; k++)
                if (ran.Next(0, 3) % 2 == 0) arr[k] = new A();
                else arr[k] = new B();
            Console.WriteLine("\nВсе объекты: ");
            foreach (A d in arr) d.getA();

            Console.WriteLine("\nОбъекты класса B: ");
            foreach (A d in arr)
                if (d is B) d.getA();

            Console.WriteLine("\nОбъекты класса A: ");
            foreach (A d in arr)
                if (d is A) d.getA();

            Console.WriteLine();
        }

    }
}
