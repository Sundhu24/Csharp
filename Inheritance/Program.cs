using System;

// Inheritance
namespace Inheritance2
{
    class Program
    {
        static void Main(string[] args)
        {
           /* Employee emp = new Employee();
            Console.WriteLine(emp.Name);*/

            Employee peter = new Employee("Peter","John", 500000);

            peter.Work();
            peter.Pause();

            Boss myboss = new Boss("Tesla", "Joe", "Hayn", 500000);

            myboss.Lead();


            Trainee traObj = new Trainee(15, 8, "fname", "name", 60000);
            traObj.Learn();
            traObj.Work();
            Console.ReadKey();
            

        }
    }

}
