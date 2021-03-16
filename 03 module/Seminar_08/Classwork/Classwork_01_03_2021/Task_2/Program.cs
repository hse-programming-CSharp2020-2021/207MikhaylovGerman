using System;
using System.Collections.Generic;

namespace Task_2
{
    class ElectronicQueue<T> : Queue<T> where T : Person
    {
        static Queue<T> Collection = new Queue<T>();

        public ElectronicQueue()
        {
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            ElectronicQueue<Person> people = new ElectronicQueue<Person>();
            people.Enqueue(new Person("dwdwdwd", "wdwdw", 11));
            people.Enqueue(new Person("wef", "kl;k", 21));
            people.Enqueue(new Person("wfwf", "ff", 31));

            people.Dequeue();
            people.Dequeue();
            people.Dequeue();

        }
    }

    class Person
    {
        string Name { get; set; }
        string Surname { get; set; }
        int Age { get; set; }

        public Person(string name, string surname, int age)
        {
            Name = name;
            Surname = surname;
            Age = age;
        }
    }
}
