using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR.Client;

namespace APISample.ConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please press enter to start signalr");
            Console.ReadLine();
            var connection = new HubConnection("http://www.useapi.com/");
            var proxy = connection.CreateHubProxy("sampleHub");
            try
            {
                connection.Start().Wait();
                proxy.On<string>("displayTime", displayTime => 
                {
                    Console.WriteLine($"Now Server time is {displayTime}");
                    Console.WriteLine();
                });
                proxy.On<string>("chating", text =>
                {
                    Console.WriteLine(text);
                    Console.WriteLine();
                });
                proxy.Invoke("sendMessage");
                proxy.Invoke("addMessage");
            }
            catch (Exception e){ Console.WriteLine(e.Message); }
            Console.ReadLine();
        }
    }
}
