using System;

namespace HelloWorld
{

    class Program
    {

        public string model;
        public string color;
        public string year;

        public Program()  // Constructor (Special Method)
        {
            model = "SUV";
            color = "Red";
            year = "2022";
        }

        static void Main(string[] args)
        {

             Program obj= new Program();
             Console.WriteLine(obj.model);
             obj.showme();
             Console.ReadLine();




        }

        void showme()
        {
            Program obj = new Program();
            Console.WriteLine(obj.model);
            Console.WriteLine(obj.color);
            Console.WriteLine(obj.year);
            
        }

       
    }






}
