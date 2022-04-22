
using System;
using System.Collections;

namespace Othercollections1
{
    class Program
    {
        public interface ITransaction
        {
            // Member Functions
            void showTransactions();
            double getAmount();
        }

        public class Transaction : ITransaction
        {
            private string tCode;
            private double amount;
            private string date;

            public Transaction(string tcode, double amt, string dt)
            {
                tCode = tcode;
                amount = amt;
                date = dt;
            }

            public double getAmount()
            {
                return amount;
            }

            public void showTransactions()
            {
                Console.WriteLine("Transactionl Code : {0}", tCode);
                Console.WriteLine("Transactionl Date : {0}", date);
                Console.WriteLine("Transactionl Amount : {0}", amount);
            }

            public void showme()
            {
                Console.WriteLine("inside Showme function");
            }
        }

        static void Main(string[] args)
        {
            Transaction t1 = new Transaction("1",75000,"22/04/2022");
            t1.showTransactions();

            t1.showme();
            Console.ReadLine();
        }

    }
}
