using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Synchronization
{ 

    class SynchExample
    {
        static Thread[] thread = new Thread[10];
        static Mutex mut = new Mutex(false,"MYMutex");

        static void RunProgram()
        {
            Console.WriteLine("Thread {0} is waiting in Queue-{1}", Thread.CurrentThread.Name  ,Thread.CurrentThread.ManagedThreadId);

            mut.WaitOne();
            Console.WriteLine("Thread {0} enters critical section-{1}", Thread.CurrentThread.Name , Thread.CurrentThread.ManagedThreadId);

            Thread.Sleep(1000);

            Console.WriteLine("Thread {0} leaves critical section-{1}", Thread.CurrentThread.Name , Thread.CurrentThread.ManagedThreadId);
            mut.ReleaseMutex();
        }




        static void Main(string[] args)
        {

            for (int i = 0; i < 10; i++)
            {
                thread[i] = new Thread(RunProgram);
                thread[i].Name = "Thread_" + i.ToString();
                thread[i].Start();
            }

            Console.Read();
        }
    }
}
