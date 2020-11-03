using System;



namespace Application
{
    class Person
    {
        public string Name { get; set; }
        public Person(string name)
        {
            Name = name;
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
                return data;
            }
            set
            {
                data = value;
            }
        }

        public Person this[int index]
        {
            get
            {
                return data[index];
            }
            set
            {
                data[index] = value;
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
        }
    }
}
