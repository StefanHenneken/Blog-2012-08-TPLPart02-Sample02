using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            new Program().Run();
        }
        public void Run()
        {
            Task task1 = new Task(() =>
            {
                Console.WriteLine("Task01 Start");
                Task task2 = new Task(() =>
                {
                    Console.WriteLine("Task02 Start");
                    Thread.SpinWait(50000000);
                    Console.WriteLine("Task02 End");
                }, TaskCreationOptions.AttachedToParent);
                task2.Start();
            });
            task1.Start();
            task1.Wait();
            Console.WriteLine("Task01 End");
            Console.ReadLine();
        }    
    }
}
