using System;
using System.Diagnostics;
using PumpFactory;

namespace GenericPump
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Let's pump up the world!");

            CreatePump(args);

            Console.ReadKey();
        }

        private static void CreatePump(string[] args)
        {
            switch (args[0])
            {
                case "Rapid":
                    // Check on the database and ensure the last Rapid pump has completed
                    // Exit if existing Rapid pump is running

                    // Update Rapid pump entry in the database to indicate a new batch is going to run
                    
                    // Start a new Rapid pump
                    var rapidPump = new Pump("Rapid", "http://getrapid.com.au/data");
                    rapidPump.Start();
                    break;

                case "Coda":
                    var codaPump = new Pump("Coda", "http://getcoda.com.au/data");
                    codaPump.Start();
                    break;
                default:
                    break;
            }
        }
    }
}
