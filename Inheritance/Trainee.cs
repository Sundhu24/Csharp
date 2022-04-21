using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance2
{
    internal class Trainee:Employee
    {
        public int WorkingHours { get; set; }
        public int SchoolHours { get; set; }

        public Trainee(int workinghours, int schoolhours, string firstname, string name, int salary):base(name,firstname,salary)
        {
            this.WorkingHours = workinghours;
            this.SchoolHours = schoolhours;
        }

        public void Learn()
        {
            Console.WriteLine("I'm learning for {0} hours", SchoolHours);
        }

        public void Work()
        {
            Console.WriteLine("I'm work for {0} hours ", WorkingHours);
        }
    }
}
