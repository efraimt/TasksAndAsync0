using System;
using System.Threading.Tasks;

namespace Cont
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Task.Run(() => DateTime.Now.Second).ContinueWith(tsk => Console.WriteLine(tsk.Result));
            var tsk = Task.Run(GetSecond);
            var t1 = tsk.ContinueWith(PrintSeconds);

            t1.Wait();
        }


        static int GetSecond()
        {
            return DateTime.Now.Second;
        }

        static void PrintSeconds(Task<int> t)
        {
            Console.WriteLine(t.Result);
        }
    }
}
