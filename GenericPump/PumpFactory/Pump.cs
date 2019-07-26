using System;
using System.Diagnostics;

namespace PumpFactory
{
    public abstract class Pump 
    {
        public string PumpName { get; }

        public string RemoteUrl { get; }

        public string EventSource { get; }
        protected Pump(string pumpName, string remoteUrl, string eventSource)
        {
            PumpName = pumpName;
            RemoteUrl = remoteUrl;
            EventSource = eventSource;

            EventLog.WriteEntry(EventSource, $"{PumpName} - started!");
            Console.WriteLine($"{PumpName} Pump started, fetching data from {RemoteUrl}");
        }

        public abstract void Start();
    }
}