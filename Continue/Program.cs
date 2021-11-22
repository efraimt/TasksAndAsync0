using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace Continue
{
    internal class Program
    {
        /// <summary>
        /// This example shows the benefit of async and await keywords
        /// Remember, that asynchronus programming can happen even if we have one core on the machine 
        ///    and we have a single threaded worker.
        /// We want to do things while CPU is not bussy,
        ///    and it's just waiting for an eternal stream (i.e IO and network operations)
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {

            //run the code number (1), then comment it and run code number (2) below
            //They do the same, just that the new way of writing - as in code # (2) -
            //               is natural and very similar to waht we have alwais wrote regular synchronus code!

            /*********************************************************************************************** 
             * CODE NUMBER (1) - The old Task.ContinueWith way of achiving Async operations while waiting
             * *********************************************************************************************/
            //DoSyncOperation();
            //var task = GetWebOldWay();
            //DoSomthingWhileWating();
            //task.Wait(); //if we don't wait for task, we dont get the message about the length of our url


            /*********************************************************************************************** 
             * (2) async await keywords to achive the same as above in a syntax that it's almost like "regular"
             * *********************************************************************************************/
            DoSyncOperation();
            var task = GetWebAsync();
            DoSomthingWhileWating();
            
            
            task.Wait(); //if we don't wait for task, we dont get the message about the length of our url

        }

        /// <summary>
        /// Regular synchronized operation
        /// </summary>
        private static void DoSyncOperation()
        {
            Console.WriteLine("I am runing syncronized");
        }


        /// <summary>
        /// This MAY run while we wating for the network operation
        /// </summary>
        private static void DoSomthingWhileWating()
        {
            Console.WriteLine("I am done while waiting for network operation");
        }

        /// <summary>
        /// Same as oldway below, just more clearer
        /// This gives aus athe opportunity to write code that looks almost as synchrous code that we have alwais wrote
        /// with small minor changes - adding the asyng and awit keywords.
        /// 
        /// THIS COMPILES to somthing very similar to GetWebOldWay!
        /// </summary>
        /// <returns>Task!</returns>
        private async static Task GetWebAsync()
        {
            var url = @"https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/async/";
            HttpClient httpClient = new HttpClient();

            Console.WriteLine("Waiting");
            string result = await httpClient.GetStringAsync(url);

            Console.WriteLine("The url content length is: " + result.Length);
        }

        /// <summary>
        /// The old way is NOT natural!
        /// We don't want to write Continue and call diffrent methhod thrue all our code!
        /// </summary>
        private static Task GetWebOldWay()
        {
            var url = @"https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/async/";
            WebClient client = new WebClient();

            Console.WriteLine("Waiting");
            var task1 = Task.Run(() =>
           {
               return client.DownloadString(url);
           });

            var task2 = task1.ContinueWith((t) =>
            {
                    Console.WriteLine("The url content length is: " + t.Result.Length);

            });
            
            return task2;
        }




    }
}
