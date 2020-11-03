using System;
using System.Linq;



namespace Application
{
    class Person
    {
        public string Name { get; set; }
        public Person(string name)
        {
            Name = name;
        }
        public Person(Person person)
        {
            Name = person.Name;
        }
        public override string ToString()
        {
            return $"Person - {Name}";
        }
    }



    class People
    {
        Person[] data;



        public People(Person[] people)
        {
            data = new Person[people.Length];
            for (int i = 0; i < people.Length; i++)
            {
                data[i] = new Person(people[i].Name);
            }
        }



        public Person[] Data
        {
            get
            {
                Person[] data2 = new Person[data.Length];
                for (int i = 0; i < data.Length; i++)
                {
                    data2[i] = new Person(data[i].Name);
                }
                return data2;
            }
            set
            {
                Person[] data3 = new Person[value.Length];
                for (int i = 0; i < value.Length; i++)
                {
                    data3[i] = new Person(value[i].Name);
                }
                data = data3;
            }
        }



        public Person this[int index]
        {
            get
            {
                return new Person(data[index]);
            }
            set
            {
                data[index] = new Person(value);
            }
        }



        public void Print()
        {
            Console.WriteLine("People:");
            for (int i = 0; i < data.Length; i++)
            {
                Console.WriteLine(data[i].ToString());
            }
        }
    }



    class MainClass
    {
        public static void Main(string[] args)
        {
            Person[] person = new Person[]
            {
                new Person("A"),
                new Person("B"),
                new Person("C"),
            };



            People people = new People(person);
            people.Print();



            person[0].Name = "AAA";
            people.Print();
            /*
             People:
                Person - A
                Person - BBB
                Person - C
            */
            Person[] person2 = people.Data;
            person2[1].Name = "BBB";
            people.Print();



            Person[] person3 = new Person[]
            {
                new Person("A"),
                new Person("B"),
                new Person("C"),
            };
            people.Data = person3;
            person3[2].Name = "CCC";
            people.Print();



            Console.WriteLine("*******");
            Console.WriteLine(people[0]);
            Person person4 = people[0];
            person4.Name = "person4";
            people.Print();
            Console.WriteLine("*******");



            Person person5 = new Person("D");
            people[0] = person5;
            people.Print();
            person5.Name = "person5";
            people.Print();
        }
    }
}

