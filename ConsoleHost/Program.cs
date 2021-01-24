using System;
using System.ServiceModel;

namespace ConsoleHost
{
    class Program
    {
        static void Main(string[] args)
        {
            using (ServiceHost host = new ServiceHost(typeof(КР_8.Service)))
            {
                Console.Title = "Server";
                host.Open();
                Console.WriteLine("Host started!");
                Console.ReadLine();
            }
        }
    }
}
