using System;
using System.Diagnostics;

namespace GenericPump
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("A pump event has been triggered ...");

            CreateEventSource();
            CreatePump(args);

            Console.ReadKey();
        }

        private static void CreateEventSource()
        {
            string source = "GenericPump";
            string log = "Application";
            if (!EventLog.SourceExists(source))
            {
                EventLog.CreateEventSource(source, log);
            }
        }

        private static void CreatePump(string[] args)
        {
            var pumpName = args[0].ToLower();
            var targetUrl = args[1].ToLower();
            PumpFactory.PumpFactory factory = new PumpFactory.PumpFactory(pumpName, targetUrl);
            var specificPump = factory.GetPump();
            specificPump?.Start();
        }
    }
}
