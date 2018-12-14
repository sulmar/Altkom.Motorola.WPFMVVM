using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Altkom.Motorola.ConsoleClient
{
    class Program
    {
        static void Main(string[] args) => MainAsync(args).GetAwaiter();


        static async Task MainAsync(string[] args)
        {
            Console.WriteLine($"#{Thread.CurrentThread.ManagedThreadId} main.");

            //CalculateAsync(1000)
            //        .ContinueWith(task => Console.WriteLine($"Result {task.Result}"));


            decimal result = await CalculateAsync(1000);

            Console.WriteLine($"Result {result}");


            //for (int i = 0; i < 100; i++)
            //{
            //    Task.Run(() => Send());
            //}

            Console.WriteLine("Press any key to exit.");

            Console.ReadKey();
        }

        private static Task<decimal> CalculateAsync(decimal amount)
        {
            return Task.Run(() => Calculate(amount));
        }


        private static decimal Calculate(decimal amount)
        {
            Console.WriteLine($"#{Thread.CurrentThread.ManagedThreadId} calculating...");

            Thread.Sleep(TimeSpan.FromSeconds(5));

            Console.WriteLine($"#{Thread.CurrentThread.ManagedThreadId} calculated.");

            return amount += 100;
        }

        private static void Send()
        {
            Console.WriteLine($"#{Thread.CurrentThread.ManagedThreadId} sending...");

            Thread.Sleep(TimeSpan.FromSeconds(5));

            Console.WriteLine($"#{Thread.CurrentThread.ManagedThreadId} sent.");


        }
            
    }


}
