
using System;
using System.Collections;

namespace Othercollections1
{
    class Program
    {
        static void Main(string[] args)
        {
          Dictionary<int, string> dic = new Dictionary<int, string>();

            dic.Add(1, "First");
            dic.Add(2, "Second");
            dic.Add(3, "third");

            foreach(KeyValuePair<int, string>kys in dic)
            {
                Console.WriteLine("{0} - {1}", kys.Key, kys.Value);
            }

            Console.ReadKey();
        }
    }
}
