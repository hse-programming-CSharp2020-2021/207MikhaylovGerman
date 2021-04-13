using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Runtime.Serialization;
using System.Xml;
using System.Xml.Serialization;

namespace Task02_xml
{
    [DataContract]
    public class Human
    {
        [DataMember]
        public string Name { get; set; }

        public Human() { }

        public Human(string name)
        {
            this.Name = name;
        }
    }

    [DataContract]
    public class Professor : Human
    {
        public Professor()
        {
        }

        public Professor(string name) : base(name) { }
    }

    [DataContract]
    public class Dept
    {
        [DataMember]
        public string DeptName { get; set; }

        [DataMember]
        List<Human> staff;

        [DataMember]
        public List<Human> Staff { get { return staff; } set { staff = value; } }

        public Dept() { }

        public Dept(string name, Human[] staffList)
        {
            this.DeptName = name;
            staff = new List<Human>(staffList);
        }
    }


    [DataContract]
    public class University
    {
        
        public University() { }

        [DataMember]
        public string UniversityName { get; set; }

        [DataMember]
        public List<Dept> Departments { get; set; }
    }


    class Program
    {
        static void Main(string[] args)
        {
            University HSE = new University();
            HSE.UniversityName = "NRU HSE";

            Human[] deptStaff = { new Professor("Ivanov"),
                      new Professor("Petrov")
                    };

            Dept SE = new Dept("SE", deptStaff);
            HSE.Departments = new List<Dept>();
            HSE.Departments.Add(SE);

            University MSU = new University();
            MSU.UniversityName = "MSU";

            Human[] deptStaffM = { new Professor("Ivanov"),  new Professor("Chizov"),
                      new Professor("Petrov")
                    };

            Dept SEM = new Dept("SEM", deptStaffM);
            MSU.Departments = new List<Dept>();
            MSU.Departments.Add(SEM);

            University[] universities = new University[] { HSE, MSU };



            //XmlSerializer binformatter = new XmlSerializer(typeof(University[]), new Type[] { typeof(Dept),
            //   typeof(Professor), typeof(Human) });


            DataContractSerializer contractSerializer = new DataContractSerializer(typeof(University[]), new Type[] { typeof(University), typeof(Professor), typeof(Dept), typeof(Human) });

            // Сериализация
            using (Stream file = new FileStream("JsonSer.json", FileMode.Create, FileAccess.Write, FileShare.None))
            {
                contractSerializer.WriteObject(file, universities);
            }


            // Десериализация
            University[] deserial;
            using (Stream file = File.OpenRead("JsonSer.json"))
            {
                deserial = (University[])contractSerializer.ReadObject(file);
                Console.WriteLine("JSON - " + deserial[0].UniversityName);
                Console.WriteLine("JSON - " + deserial[1].UniversityName);
            }



            foreach (Dept d in deserial[0].Departments)
                foreach (Human h in d.Staff)
                {
                    if (h is Professor)
                        Console.WriteLine(d.DeptName + " prof.: " + h.Name);
                }



            foreach (Dept d in deserial[1].Departments)
                foreach (Human h in d.Staff)
                {
                    if (h is Professor)
                        Console.WriteLine(d.DeptName + " prof.: " + h.Name);
                }

            Console.ReadKey();
        }
    }
}