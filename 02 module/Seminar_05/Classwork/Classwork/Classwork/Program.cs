using System;

class Person
{
    public string FullName { get; set; }
    public DateTime BirthDate { get; set; }
    public bool IsMale { get; set; }

    public Person(string f, DateTime d, bool m)
    {
        FullName = f;
        BirthDate = d;
        IsMale = m;
    }

    public virtual void ShowInfo()
    {
        Console.WriteLine($"{FullName} {BirthDate} {IsMale}");
    }
}

class Employee : Person
{
    public string CompanyName { get; set; }
    public string Post { get; set; }
    public string Schedule { get; set; }
    public decimal Salary { get; set; }

    public Employee(string f, DateTime d, bool m, string comName, string post, string shedule, decimal sallary) : base(f, d, m)
    {
        CompanyName = comName;
        Post = post;
        Schedule = shedule;
        Salary = sallary;
    }

    public override void ShowInfo()
    {
        Console.WriteLine($"{FullName} {BirthDate} {IsMale} {CompanyName} {Post} {Schedule} {Salary}");
    }

}

class Program
{
    static void Main()
    {
        Person[] array = new Person[1];
        array[0] = new Employee("Arseniy", new DateTime(2003, 05, 21), true, "Arseniy.Inc", "CEO", "0 busy days", decimal.MaxValue);

        for (int i = 0; i < array.Length; i++)
        {
            array[i].ShowInfo();
        }
    }
}
