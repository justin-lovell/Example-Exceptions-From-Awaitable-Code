using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionsFromAwaitableCode
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                DoAsyncOperationAndWait().Wait();
            }
            catch(Exception ex)
            {
                Console.WriteLine("Main() method:");
                Console.WriteLine(ex);
            }

            Console.ReadKey();
        }

        private static async Task DoAsyncOperationAndWait()
        {
            try
            {
                await DoAsyncOperationAsTask();
            }
            catch (Exception ex)
            {
                Console.WriteLine("DoAsyncOperationAndWait() method:");
                Console.WriteLine(ex);
                throw;
            }
        }

        private static Task DoAsyncOperationAsTask()
        {
            return Task.Run(() =>
                                {
                                    throw new Exception("Hello there!");
                                });
        }
    }
}
