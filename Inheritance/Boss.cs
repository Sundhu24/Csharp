using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance2
{
    internal class Boss:Employee
    {
        public string CompanyCar { get; set; }
        
        public Boss(string companycar, string name, string firstname, int salary):base(name, firstname, salary)
        {
            this.CompanyCar = companycar;
        }

        public void Lead()
        {
            Console.WriteLine("My Name is {0} {1}", FirstName, Name);
        }

    }
}
