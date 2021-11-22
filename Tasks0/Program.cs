using System;
using System.Threading;
using System.Threading.Tasks;

namespace Tasks0
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Task task = new Task(() => Console.WriteLine("I am runing in a task"));
            Console.WriteLine(task.Status);
            task.Start();
            Console.WriteLine(task.Status);
            Thread.Sleep(1);
            Console.WriteLine(task.Status);

            if (task.IsFaulted)
                Console.WriteLine(task.Exception.ToString());


            var num = 13;

            Task.Run(() => Console.WriteLine(num = num * 3 - 30));
            Task.Factory.StartNew(() => Console.WriteLine(num = num * num * 3));

            //Use regulrly
            Task.Run(() => Console.WriteLine(num = num * 2 + 3));

            Task<string> tsk1 = Task.Factory.StartNew(() => { return DateTime.Now.ToString(); });
         
            Console.WriteLine("While waiting");

            tsk1.Wait();
            Console.WriteLine(tsk1.Result);

            Task.WaitAny(task, tsk1);
            Console.WriteLine(tsk1.Result);




        }
    }
}
