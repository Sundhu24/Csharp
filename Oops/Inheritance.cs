using System;

namespace HelloWorld
{
    // OOP - Object Oriented Programming 
    // 1. Class and Object
    // 2. Inheritance
    // 3. Polymophism
    // 4. Abstraction

    class Vehicle
    {
        public string brand = "Tesla";

        public void honk()
        {
            Console.WriteLine("Sound...");
        }
    }

    class Car : Vehicle
    {
        public string model = "V1";
    }

    class Program 
    {
        static void Main(string[] args)
        {
            Car car = new Car();
            car.honk();

            Console.WriteLine(car.model + "-" + car.brand);
            Console.ReadLine();
        }
       
    }

}
