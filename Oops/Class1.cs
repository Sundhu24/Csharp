using System;

namespace HelloWorld
{

    class Car
    {

        // Access Modifier public, private 
        public string color = "Red";

        public void printme()
        {
            Console.WriteLine(color);
        }
    }
    class Program
    {
   
        static void Main(string[] args)
        {

            Car carObj = new Car();

            Car carObj1 = new Car();
            carObj.printme();
            carObj.color = "Yellow";
            carObj.printme();
            carObj1.printme();
            //Console.WriteLine(carObj.color);
            Console.ReadLine();
        }

       
    }

}
