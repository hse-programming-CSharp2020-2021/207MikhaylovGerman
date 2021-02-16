using System;
using System.Collections.Generic;

namespace A
{
    /// <summary>
    /// Пассажир
    /// </summary>
    public class Passenger
    {
        string name;
        string lastName;
        int age;
        public bool IsOld { private set; get; }

        public string Name
        {
            set
            {
                name = ValidateName(value);
            }
            get
            {
                return name;
            }
        }

        private string ValidateName(string value)
        {
            bool isCorrect = false;
            if (value.Length <= 30)
            {
                isCorrect = true;
                foreach (var ch in value)
                {
                    if (!(ch < 'Z' && ch > 'A') && !(ch < 'z' & ch > 'a'))
                    {
                        isCorrect = false;
                    }
                }
            }
            if (isCorrect)
                return value;
            else
            {
                throw new ArgumentException();
            }
        }

        public string LastName
        {
            set
            {
                lastName = ValidateName(value);
            }
            get
            {
                return lastName;
            }
        }
        public int Age
        {
            set
            {
                if (value > 0)
                {
                    age = value;
                }
                else
                {
                    throw new ArgumentException("Age is less or equal than 0");
                }
            }
            get { return age; }
        }

        public override string ToString()
        {
            return $"Passenger {Name} {LastName} Age: {Age}";
        }
    }

    /// <summary>
    /// Пассажир с детьми
    /// </summary>
    public class PassengerWithChildren : Passenger
    {
        int numberOfChildren;
        public bool IsNewBorn { set; get; }
        public int NumberOfChildren
        {
            set
            {
                if (value > 0)
                {
                    numberOfChildren = value;
                }
                else
                {
                    throw new ArgumentException("Number of childs is less or equal than 0");
                }
            }
            get { return numberOfChildren; }
        }
    }

    /// <summary>
    /// Очередь на посадку состоит из двух подочередей: обычной и приоритетной
    /// Пассажиры приоритетной очереди обслуживаются вне очереди
    /// </summary>
    public class PassengerQueue
    {
        // if passenger is ordinary we use ordinaryQueue
        Queue<Passenger> ordinaryQueue = new Queue<Passenger>();
        // if passenger is old or with newborns we use priorityQueue
        Queue<Passenger> priorityQueue = new Queue<Passenger>();

        public void AddToQueue(Passenger newPassenger)
        {
            if (newPassenger.Age > 65 || newPassenger is PassengerWithChildren && ((PassengerWithChildren)newPassenger).IsNewBorn) priorityQueue.Enqueue(newPassenger);
            else ordinaryQueue.Enqueue(newPassenger);
        }
        public void StartServingQueue()
        {
            if (priorityQueue.Count <= 3)
            {
                for (int i = 0; i < priorityQueue.Count; i++)
                    priorityQueue.Dequeue();
            }
            else
            {
                int shortest = ordinaryQueue.Count > priorityQueue.Count ? priorityQueue.Count : ordinaryQueue.Count;
                int longest = ordinaryQueue.Count > priorityQueue.Count ? ordinaryQueue.Count : priorityQueue.Count;
                while (shortest > 0)
                {
                    priorityQueue.Dequeue();
                    ordinaryQueue.Dequeue();
                }
                for (int i = 0; i < longest; i++)
                {
                    ordinaryQueue.Dequeue();
                }
            }
        }
    }


    class MainClass
    {
        public static void Main()
        {
            Random random = new Random();
            // создаем рандомных пассажиров.

            PassengerQueue pq = new PassengerQueue();
            for (int i = 0; i < 20; i++)
            {
                if (i % 5 == 0)
                {
                    PassengerWithChildren p = new PassengerWithChildren();
                    p.Name = random.Next(1000, 2000).ToString();
                    p.LastName = random.Next(30000, 40000).ToString();
                    p.NumberOfChildren = random.Next(1, 3);
                    p.Age = random.Next(18, 80);
                    p.IsNewBorn = random.Next(100) <= 50 ? true : false;
                    pq.AddToQueue(p);
                }
                else
                {
                    Passenger p = new Passenger();
                    p.Name = random.Next(1000, 2000).ToString();
                    p.LastName = random.Next(30000, 40000).ToString();
                    p.Age = random.Next(18, 80);
                    pq.AddToQueue(p);
                }

            }
            pq.StartServingQueue();
        }
    }
}
