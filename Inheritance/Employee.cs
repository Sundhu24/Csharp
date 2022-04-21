using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance2
{
    internal class Employee
    {
        public string Name { get; set; }
        public string FirstName { get; set; }
        public int Salary { get; set; }

        public Employee(string name, string firstname, int salary)
        {
            this.Name = name;
            this.FirstName = firstname;
            this.Salary = salary;
        }
        

        public void Work()
        {
            Console.WriteLine("I'am Working");
        }

        public void Pause()
        {
            Console.WriteLine("I'm having a break");
        }
    }
}
