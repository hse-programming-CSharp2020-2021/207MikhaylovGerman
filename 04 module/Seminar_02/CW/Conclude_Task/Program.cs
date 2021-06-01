using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Conclude_Task
{
    class Program
    {
        static async System.Threading.Tasks.Task Main(string[] args)
        {
            Random random = new Random();

            ColorConsoleClass[] symbls = new ColorConsoleClass[10];

            for (int i = 0; i < 10; i++)
            {
                symbls[i] = new ColorConsoleClass((char)random.Next(10, 50), random.Next(), random.Next(), random.Next());
            }

            // DataContract ------------------------------------------

            DataContract(symbls);


            // Binary ------------------------------------------

            Binary(symbls);


            // XML ------------------------------------------

            XML(symbls);

            // JSON ------------------------------------------

            JSON(symbls);

        }

        private static void JSON(ColorConsoleClass[] symbls)
        {
            // Сериализация
            using (Stream file = new FileStream("JsonSer.json", FileMode.Create, FileAccess.Write, FileShare.None))
            using (StreamWriter writer = new StreamWriter(file))
            {
                writer.Write(JsonSerializer.Serialize(symbls));
            }


            // Десериализация
            ConsoleSymbolClass[] deserial4;
            using (Stream file = File.OpenRead("Ser.json"))
            using (StreamReader reader = new StreamReader(file))
            {

                deserial4 = JsonSerializer.Deserialize<ColorConsoleClass[]>(reader.ReadToEnd());
                for (int i = 0; i < deserial4.Length; i++)
                {
                    Console.WriteLine($"JSON -  {deserial4[i].Symb},  {deserial4[i].X}, {deserial4[i].Y}");
                }
            }
        }

        private static void XML(ColorConsoleClass[] symbls)
        {
            // Сериализация
            using (Stream file = new FileStream("Ser.xml", FileMode.Create, FileAccess.Write, FileShare.None))
            {
                XmlSerializer formatter = new XmlSerializer(typeof(ColorConsoleClass));
                formatter.Serialize(file, symbls);
            }


            // Десериализация
            ConsoleSymbolClass[] deserial3;
            using (Stream file = File.OpenRead("Ser.xml"))
            {
                XmlSerializer formatter = new XmlSerializer(typeof(ConsoleSymbolClass));

                deserial3 = (ColorConsoleClass[])formatter.Deserialize(file);
                for (int i = 0; i < deserial3.Length; i++)
                {
                    Console.WriteLine($"JSON -  {deserial3[i].Symb},  {deserial3[i].X}, {deserial3[i].Y}");
                }
            }
        }

        private static void Binary(ColorConsoleClass[] symbls)
        {
            // Сериализация
            using (Stream file = new FileStream("Ser.bin", FileMode.Create, FileAccess.Write, FileShare.None))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(file, symbls);
            }


            // Десериализация
            ConsoleSymbolClass[] deserial2;
            using (Stream file = File.OpenRead("Ser.bin"))
            {
                BinaryFormatter formatter = new BinaryFormatter();

                deserial2 = (ColorConsoleClass[])formatter.Deserialize(file);
                for (int i = 0; i < deserial2.Length; i++)
                {
                    Console.WriteLine($"JSON -  {deserial2[i].Symb},  {deserial2[i].X}, {deserial2[i].Y}");
                }
            }
        }

        private static void DataContract(ColorConsoleClass[] symbls)
        {
            DataContractSerializer contractSerializer = new DataContractSerializer(typeof(ColorConsoleClass[]));

            // Сериализация
            using (Stream file = new FileStream("Ser.xml", FileMode.Create, FileAccess.Write, FileShare.None))
            {
                contractSerializer.WriteObject(file, symbls);
            }

            // Десериализация
            ConsoleSymbolClass[] deserial1;
            using (Stream file = File.OpenRead("Ser.xml"))
            {
                deserial1 = (ColorConsoleClass[])contractSerializer.ReadObject(file);
                for (int i = 0; i < deserial1.Length; i++)
                {
                    Console.WriteLine($"JSON -  {deserial1[i].Symb},  {deserial1[i].X}, {deserial1[i].Y}");
                }
            }
        }
    }

    [Serializable]
    [DataContract]
    public class ConsoleSymbolClass
    {
        private char symb;
        private  int x;
        private int y;

        [DataMember] public char Symb { get => symb; set { symb = value; } }
        [DataMember] public int X { get => x; set { x = value; } }
        [DataMember] public int Y { get => y; set { y = value; } }

        public ConsoleSymbolClass(char smb, int x, int y)
        {
            symb = smb;
            this.x = x;
            this.y = y;

        }
        public ConsoleSymbolClass() { }
    }

    [Serializable]
    [DataContract]
    public class ColorConsoleClass : ConsoleSymbolClass
    {
        private int color;

        [DataMember] public int Color { get => color; set { color = value; } }

        public ColorConsoleClass(char smb, int x, int y, int color) : base(smb, x, y)
        {
            Color = color;
        }
        public ColorConsoleClass() { }

    }
}
