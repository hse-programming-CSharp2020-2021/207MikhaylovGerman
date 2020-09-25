using System;
using System.Threading;
/* Python algorithm (for heart).
 * from time import time
 *
 *   def gcd_gummy(a: int,b: int) -> int:
 *       d = min(a,b)
 *       while a % d != 0 or b % d != 0:
 *           d -= 1
 *       return d
 *
 *   def gcd_euclid(a: int,b: int) -> int:
 *       while a!= b:
 *           if  a>b :
 *               a -= b
 *           else:
 *           b -= a
 *       return a
 *   def gcd_euclid_enxanced (a: int,b: int) -> int:
 *       while a != 0 and b != 0 :
 *           if a > b :
 *               a = a % b
 *           else: 
 *               b = b % a
 *       return a+b
 *   def qcd_euclid_improved (a,b):
 *       while b != 0 :
 *      residue= a % b
 *      a = b
 *      b = residue
 *      return a
 *
 *   a = int(input("a= "))
 *   b = int(input("b= "))
 *   for f in (qcd_euclid_improved,gcd_euclid_enxanced,
 *           gcd_euclid,gcd_gummy):
 *       t = time()
 *       gcd = f(a,b)
 *       dt = time() - t
 *       print(gcd, "находит ответ за время", dt*10**6 ,"микросекунд")
 */

namespace Homework_01
{
    class Program
    {   /// <summary>
        /// Algorithm gummy
        /// </summary>
        /// <param name="a">first number</param>
        /// <param name="b">second number</param>
        /// <returns>gcd</returns>
        static int gcd_gummy(ref int a, ref int b)
        {
            int d = Math.Min(a, b);
            while (a % d != 0 | b % d != 0)
            {
                d -= 1;
            }
            return d;

        }
        /// <summary>
        /// Algorithm gcd euclid
        /// </summary>
        /// <param name="a">first number</param>
        /// <param name="b">second number</param>
        /// <returns>gcd</returns>
        static int gcd_euclid(ref int a, ref int b)
        {
            while (a != b)
            {
                if (a > b)
                {
                    a -= b;
                }
                else
                {
                    b -= a;
                }
            }
            return a;
        }
        /// <summary>
        /// Algorithm gcd euclid_enxanced
        /// </summary>
        /// <param name="a">first number</param>
        /// <param name="b">second number</param>
        /// <returns>gcd</returns>
        static int gcd_euclid_enxanced(ref int a, ref int b)
        {
            while (a != 0 & b != 0)
            {
                if (a > b)
                {
                    a = a % b;
                }
                else
                {
                    b = b % a;
                }
            }
            return a + b;
        }
        /// <summary>
        /// Algorithm gcd euclid_improved
        /// </summary>
        /// <param name="a">first number</param>
        /// <param name="b">second number</param>
        /// <returns>gcd</returns>
        static int qcd_euclid_improved(ref int a, ref int b)
        {
            while (b != 0)
            {
                int residue = a % b;
                a = b;
                b = residue;
            }
            return a;
        }
        /// <summary>
        /// Testing and running algorithms
        /// </summary>
        static void Algorithm_executor_and_tester(ref int a, ref int b)
        {
            long ellapledTicks;
            int result;
            // run qcd_euclid_improved.
            ellapledTicks = DateTime.Now.Ticks;
            result = Program.qcd_euclid_improved(ref a, ref b);
            ellapledTicks = DateTime.Now.Ticks - ellapledTicks;
            Console.WriteLine($"Результат {result}, выполнено за {ellapledTicks} тактов");

            /// run gcd_euclid_enxanced.
            ellapledTicks = DateTime.Now.Ticks;
            result = Program.gcd_euclid_enxanced(ref a, ref b);
            ellapledTicks = DateTime.Now.Ticks - ellapledTicks;
            Console.WriteLine($"Результат {result}, выполнено за {ellapledTicks} тактов");

            // run gcd_euclid.
            ellapledTicks = DateTime.Now.Ticks;
            result = Program.gcd_euclid(ref a, ref b);
            ellapledTicks = DateTime.Now.Ticks - ellapledTicks;
            Console.WriteLine($"Результат {result}, выполнено за {ellapledTicks} тактов");

            // run gcd_gummy.
            ellapledTicks = DateTime.Now.Ticks;
            result = Program.gcd_gummy(ref a, ref b);
            ellapledTicks = DateTime.Now.Ticks - ellapledTicks;
            Console.WriteLine($"Результат {result}, выполнено за {ellapledTicks} тактов");
        }
        static void Main(string[] args)
        {
            int a;
            Console.WriteLine("Введите a = ");
            while (!int.TryParse(Console.ReadLine(), out a))
            {
                Console.WriteLine("Incorrect input");
            }
            Console.WriteLine("Введите b = ");
            int b;
            while (!int.TryParse(Console.ReadLine(), out b))
            {
                Console.WriteLine("Incorrect input");
            }
            // testing algorithm on time and run.
            Program.Algorithm_executor_and_tester(ref a, ref b);


        }
    }
}
