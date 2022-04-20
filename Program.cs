using System;

namespace Mynamespace
{
    class Program
    {
        public static void Main(string[] args)
        {

            Mul_fl();
            quo_rem();
            simpleinterest();
            count_words();
            average();

        }
       
       
        
        static void Mul_fl()
        {


            Console.WriteLine("Enter two float numbers:");
            double d1 = Convert.ToDouble(Console.ReadLine());
            double d2 = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("The product of two float numbers is : {0}", d1 * d2);
            Console.ReadKey();
        }
        static void quo_rem()
        {
            Console.WriteLine("Enter Two numbers");
            int n1 = Convert.ToInt32(Console.ReadLine());
            int n2 = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("The Quotient is:{0}", n1 / n2);
            Console.WriteLine("The Remainderis:{0}", n1 % n2);

            Console.ReadLine();
        }
        static void simpleinterest()
        {
            Console.WriteLine("Enter Principle");
            int p = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter number of years");
            int n = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter interest rate");
            int i = Convert.ToInt32(Console.ReadLine());

            double simpinterest = (p * n * i) / 100;

            Console.WriteLine("The Simple Interest is:{0}", simpinterest);


            Console.ReadLine();
        }
        static void average()
        {
            Console.WriteLine("Enter three numbers:");
            int n1 = Convert.ToInt32(Console.ReadLine());
            int n2 = Convert.ToInt32(Console.ReadLine());
            int n3 = Convert.ToInt32(Console.ReadLine());

            float f = (n1 + n2 + n3) / 3;
            Console.WriteLine("The average of three numbers is : {0}", f);
            Console.ReadKey();

        }
        static void count_words()
        {
            string s;
            Console.Write("Enter String  : ");
            s = Console.ReadLine();
            string[] words = s.Split(' ');
            Console.WriteLine("Count of words :" + words.Length);
            Console.ReadKey();
        }
    }
}