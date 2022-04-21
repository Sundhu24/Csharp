using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Array2
{
    class Program
    {
        static void Main(string[] args)
        {

            ArrayList myArrayList = new ArrayList();

            myArrayList.Add(25);
            myArrayList.Add("hello");
            myArrayList.Add(30);
            myArrayList.Add(40);
            myArrayList.Add(50);

            myArrayList.Remove(25);
            myArrayList.Remove(30);
            myArrayList.Remove(25);

            Console.WriteLine(myArrayList.Count);

            double sum = 0;
            foreach(object obj in myArrayList)
            {
                if(obj is int)
                {
                    sum += Convert.ToDouble(obj);
                }else if(obj is string)
                {
                    Console.WriteLine(obj);
                }
            }

            Console.WriteLine(sum); //

            Console.ReadKey();
        }
    }
}
