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
            data = people;
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
        }
    }
}

