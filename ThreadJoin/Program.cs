using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadJoin
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Main thread started");

            Thread thread1 = new Thread(Thread1Function);
            Thread thread2 = new Thread(Thread2Function);


            thread1.Start();
            thread2.Start();

            //thread1.Join();
            //Console.WriteLine("Thread 1 function done");

            if (thread1.Join(1000))
            {
                Console.WriteLine("Thread 1 function done");
            }
            else
            {
                Console.WriteLine("Thread 1 function wasn't done within 1 second");
            }

            thread2.Join();
            Console.WriteLine("Thread 2 function done");

            if(thread1.IsAlive)
            {
                Console.WriteLine("Thread 1 is still doing stuff");
            }
            else
            {
                Console.WriteLine("Thread 1 completed");
            }


            Console.WriteLine("Main thread ended");
            Console.ReadKey();
        }

        static void Thread1Function()
        {
            Console.WriteLine("Thread 1 function started");
            Thread.Sleep(3000);
            Console.WriteLine("Thread 1 function coming back to caller");
        }
        static void Thread2Function()
        {
            Console.WriteLine("Thread 2 function started");
        }
    }
}
