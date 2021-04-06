using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

/* 
    Класс Student (студент) включает фамилию и номер курса.

    Класс Group (группа) включает ее обозначение и список студентов.

    Определить две группы и сохранить их в файле, применяя двоичную сериализацию.

    Прочитать данные из файла и восстановить объекты класса Группа.
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

    [Serializable]
    class Group
    {
        public string name;
        public Student[] Students;

        public Group(string name, Student[] students)
        {
            this.name = name;
            Students = students;
        }

        public Student this[int index]
        {
            get => Students[index];
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
                formatter.Serialize(stream, new Group("Group 1", students));
            }


            BinaryFormatter formatter1 = new BinaryFormatter();
            using (Stream stream1 = new FileStream("MyFile.bin", FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                Group group = (Group)formatter1.Deserialize(stream1);

                Console.WriteLine(group.name);

                // Here's the proof.  
                for (int i = 0; i < n; i++)
                {
                    Console.WriteLine(group[i].Name);
                }

            }
        }
    }
}

