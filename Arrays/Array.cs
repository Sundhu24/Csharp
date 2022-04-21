using System;

namespace HelloWorld
{

    class Program
    {
        static void Main(string[] args)
        {
            /*string sentence;
            Console.Write("Enter String  : ");
            sentence = Console.ReadLine();
            string[] words = sentence.Split('-');
       
            Console.WriteLine("Count of words :" + words.Length); */

            string[] cars = { "BMW", "FORD", "Volvo", "Tesla" };
            int[] num = { 10,3,5,22,100 };


            /*for(int i = 0; i < cars.Length; i++)
            {
                Console.WriteLine(cars[i]);
            }*/

            foreach (string i in cars)
            {
                Console.WriteLine(i);
            }

            Console.WriteLine("--------");
            Array.Sort(num);
            foreach (int i in num)
            {
                Console.WriteLine(i);
            }

            Array.Reverse(num);


            Console.WriteLine("--------");
            foreach (int i in num)
            {
                Console.WriteLine(i);
            }

            Console.WriteLine("--------");

            Console.WriteLine(num.Max());
            Console.WriteLine(num.Min());
            Console.WriteLine(num.Sum());


            Console.ReadLine();
            
        }

       
    }


}
