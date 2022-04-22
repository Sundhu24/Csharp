
using System;
using System.Collections;

namespace Othercollections1
{
    class Program
    {
        // Thread
        public static void CallToChildThread()
        {
            Console.WriteLine("Child thread starts");

            // the thread is pasused for 5000 milliseconds
            int sleepfor = 10000;
            Console.WriteLine("Child thread paused for {0} seconds", sleepfor / 1000);
            Thread.Sleep(sleepfor);
            Console.WriteLine("Child thread resumes");
        }
        static void Main(string[] args)
        {

            //Thread th = Thread.CurrentThread;
            //th.Name = "MainThread";

            ThreadStart childref = new ThreadStart(CallToChildThread);
            Console.WriteLine("Inside the Mainthread: Creating a child thread");

            Thread childThread = new Thread(childref);
            childThread.Start();

    
            Console.ReadLine(); 
        }   

    }
}
