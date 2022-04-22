
using System;
using System.Collections;

namespace Othercollections1
{
    class Program
    {

        static void Main(string[] args)
        {
            // Last In First Out
        Stack<int> stack = new Stack<int>();

            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            stack.Push(4);  

            foreach(int x in stack)
            {
                Console.WriteLine(x); // 4,3,2,1
            }

            Queue<int> q = new Queue<int>();

            q.Enqueue(1);
            q.Enqueue(2);
            q.Enqueue(3);
            q.Enqueue(4);


            foreach(var x in q)
            {
                Console.WriteLine(x); // 1,2,3,4
            }
            Console.ReadKey();
        }



    }
}
