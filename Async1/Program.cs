using System;
using System.Threading.Tasks;

namespace Async1
{
    internal class Program
    {
        static async void Main(string[] args)
        {
            var tsk = InnerAsync();
            Console.WriteLine("After call to inner");

            tsk.Wait();
        }

        static async Task<string> InnerAsync()
        {
            Console.WriteLine("start inner");
            var x = await Task.Run(() =>
            {
                Task.Delay(4000);
                //for (int i = 0; i < 100; i++)
                //{
                //    Console.WriteLine("inner");
                //}
                return 30;
            });

            Console.WriteLine("end inner");
            return "Done";
        }

    }
}
