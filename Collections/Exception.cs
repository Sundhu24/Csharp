
using System;
using System.Collections;

namespace Othercollections1
{
    class Program
    {

        static void Main(string[] args)
        {
            // Exception Handling
            try
            {
                Console.WriteLine("Enter a number:");
                int num = int.Parse(Console.ReadLine());
                Console.WriteLine(num);
            }
            catch
            {
                Console.WriteLine("Invalid Input");
            }
            finally
            {
                Console.WriteLine("Re-enter new value");
            }
           

            Console.ReadKey();
        }



    }
}
