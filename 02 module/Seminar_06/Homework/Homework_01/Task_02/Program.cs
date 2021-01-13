using System;

namespace Task_02
{
    class TestOverride
    {
        public class Employee
        {
            public string name;

            protected decimal basepay;

            public Employee(string name, decimal basepay)
            {
                this.name = name;
                this.basepay = basepay;
            }

            public virtual decimal CalculatePay()
            {
                return basepay;
            }
        }

        public class SalesEmployee : Employee
        {
            private decimal salesbonus;

            public SalesEmployee(string name, decimal basepay,
                      decimal salesbonus) : base(name, basepay)
            {
                this.salesbonus = salesbonus;
            }

            public override decimal CalculatePay()
            {
                return basepay + salesbonus;
            }
        }

        public class PartTimeEmployee : Employee
        {
            private int jobdays;
            private int basicPayDay = 25;

            public PartTimeEmployee(string name, decimal basepay,
                      int jobdays) : base(name, basepay)
            {
                this.jobdays = jobdays;
            }

            public override decimal CalculatePay()
            {
                return basepay * jobdays / basicPayDay;
            }
        }

        static void Main()
        {
            var employee1 = new SalesEmployee("Alice",
                          1000, 500);
            var employee2 = new Employee("Bob", 1200);

            Console.WriteLine($"Employee1 {employee1.name} earned: {employee1.CalculatePay()}");
            Console.WriteLine($"Employee2 {employee2.name} earned: {employee2.CalculatePay()}");
        }
    }
}
