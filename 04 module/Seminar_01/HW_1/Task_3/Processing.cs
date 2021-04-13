using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace Task_3
{
    delegate void Qdelegate(List<Quadratic> quadratic);

    class Processing
    {
        static Random random = new Random();

        public static void SolutionReal(List<Quadratic> eq)
        {
            for (int i = 0; i < eq.Count; i++)
            {
                Console.WriteLine(eq.ToString() + "  дискриминант = " +
            eq[i].Discriminant);
                if (eq[i].Discriminant >= 0)
                {
                    Console.WriteLine($"\tКорни: Х1={eq[i].X1:g3}  \tX2={eq[i].X2:g3}");
                }
            }
            
        }
        public static void PrintEq(List<Quadratic> eq)
        {
            for (int i = 0; i < eq.Count; i++)
            {
                Console.WriteLine(eq.ToString() + "  дискриминант = "
                + (eq[i].Discriminant).ToString("g3"));
            }
        }

        public static void WriteFile(string nameFile, int numb)
        {
            using (FileStream streamOut = new FileStream(nameFile, FileMode.Create))
            {
                XmlSerializer writer = new XmlSerializer(typeof(List<Quadratic>), new Type[] { typeof(Quadratic)});

                List<Quadratic> list = new List<Quadratic>();

                for (int j = 0; j < numb; j++)
                {
                    try
                    {
                        Quadratic q = new Quadratic(random.Next(-10, 11),
                            random.Next(-10, 11), random.Next(-10, 11));

                        list.Add(q);
                    }
                    catch
                    {
                        // Заменить вырожденное уравнение:
                        j--;
                        continue;
                    }
                }
                writer.Serialize(streamOut, list);

            }

        }

        public static void Process(string fileName, Qdelegate qDel)
        {
            using (FileStream streamIn = new FileStream(fileName, FileMode.Open))
            {
                XmlSerializer reader = new XmlSerializer(typeof(List<Quadratic>), new Type[] { typeof(Quadratic)});
                List<Quadratic> eq;
                while (true)
                    try
                    {
                        eq = (List<Quadratic>)reader.Deserialize(streamIn);
                        qDel(eq);
                    }
                    catch (SerializationException) { streamIn.Close(); break; }
            }
        }   
    }
}
