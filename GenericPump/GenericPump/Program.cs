using System;
using System.Diagnostics;

namespace GenericPump
{
    /// <summary>
    /// The console program GenericPump is triggered from Microsoft Scheduler.
    /// You can define multiple tasks, for example: one for Rapid pump and one for Coda pump to trigger this console app.
    /// The console app eventually makes use of the PumpFactory and start the intended pump to start reading and processing data.
    /// </summary>
    class Program
    {
        private const string GenericPumpSource = "Generic Pump";
        private const string GenericPumpLog = "Application";


        static void Main(string[] args)
        {
            Console.WriteLine("A pump event has been triggered ...");

            CreateEventSource();
            CreatePump(args);

            Console.ReadKey();
        }

        private static void CreateEventSource()
        {
            if (!EventLog.SourceExists(GenericPumpSource))
            {
                EventLog.CreateEventSource(GenericPumpSource, GenericPumpLog);
            }
        }

        private static void CreatePump(string[] args)
        {
            var pumpName = args[0].ToUpper();
            var targetUrl = args[1].ToUpper();
            EventLog.WriteEntry(GenericPumpSource, $"Creating {pumpName} pump ...");
            PumpFactory.PumpFactory factory = new PumpFactory.PumpFactory(pumpName, targetUrl, GenericPumpSource);
            var specificPump = factory.GetPump();
            EventLog.WriteEntry(GenericPumpSource, $"Starting {pumpName} pump ...");
            specificPump?.Start();
            EventLog.WriteEntry(GenericPumpSource, $"Stopping {pumpName} pump ...");
        }
    }
}
