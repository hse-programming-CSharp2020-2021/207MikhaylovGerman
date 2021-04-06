using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;


/* 
 Класс Student (студент) включает фамилию и номер курса.
 В основной программе сосздать массив из n студентов, сохранить в файл и восстановить из файла. Использовать сериализацию.
*/


namespace Task_1
{
    [Serializable]
    public class Student
    {
        private string name;

        private int course;

        public string Name { get => name; }

        public int Course { get => course; }

        public Student(string name, int course)
        {
            this.name = name;
            this.course = course;
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Student[] students = new Student[n];
            for (int i = 0; i < n; i++)
            {
                students[i] = new Student($"ИМЯ({i})", i % 4);
            }

            BinaryFormatter formatter = new BinaryFormatter();
            using (Stream stream = new FileStream("MyFile.bin", FileMode.Create, FileAccess.Write, FileShare.None))
            {
                formatter.Serialize(stream, students);
            }


            BinaryFormatter formatter1 = new BinaryFormatter();
            using (Stream stream1 = new FileStream("MyFile.bin", FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                Student[] stds = (Student[])formatter1.Deserialize(stream1);

                // Here's the proof.  
                for (int i = 0; i < n; i++)
                {
                    Console.WriteLine(String.Concat(stds[i].Name, " ", stds[i].Course));
                }
            }

            Console.ReadKey();
        }
    }
}
