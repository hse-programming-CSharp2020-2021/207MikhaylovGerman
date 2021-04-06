using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace Task_3
{

    [Serializable]
    public class Professor : Human
    {
        public Professor(string name) : base(name)
        {

        }

        public Professor() { }
    }


    [Serializable]
    public class Dept
    {
        public string DeptName { get; set; }

        List<Human> staff;

        public List<Human> Staff { get { return staff; } }

        public Dept()
        {

        }

        public Dept(string name, Human[] staffList)
        {
            this.DeptName = name;
            staff = new List<Human>(staffList);

        }

    }

    [Serializable]
    public class University
    {
        public string UniversityName { get; set; }

        public List<Dept> Departments { get; set; }

        public University() { }

        public University(string name, List<Dept> depts)
        {
            UniversityName = name;
            Departments = depts;
        }

    }

    [Serializable]
    public class Human
    {

        public string Name { get; set; }

        public Human() { }

        public Human(string name)
        {
            this.Name = name;
        }

    }

    class Program
    {
        static void Main(string[] args)
        {

            using (Stream stream = new FileStream("University.xml", FileMode.Create, FileAccess.Write, FileShare.None))
            {
                List<Dept> depts = new List<Dept>();
                depts.Add(new Dept("fcs", new Human[] { new Human("dd"), new Professor("Dshkv") }));
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(University), new Type[] { typeof(Human), typeof(Dept), typeof(Professor), });
                University university = new University("hse", depts);

                xmlSerializer.Serialize(stream, university);
            }

            using (Stream stream = new FileStream("University.xml", FileMode.Open, FileAccess.Read))
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(University), new Type[] { typeof(Human), typeof(Dept), typeof(Professor), });

                University unvst = (University)xmlSerializer.Deserialize(stream);
            }
        }
    }
}