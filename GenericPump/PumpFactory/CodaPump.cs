using System;
using System.Diagnostics;

namespace PumpFactory
{
    public class CodaPump : Pump, IPumpOperation
    {
        public CodaPump(string pumpName, string remoteUrl, string eventSource) : base(pumpName, remoteUrl, eventSource)
        {
        }
        public override void Start()
        {
            for (int i = 0; i < 3; i++)
            {
                Fetch();
                Update();
            }
        }

        public void Fetch()
        {
            EventLog.WriteEntry(EventSource, $"{PumpName} pump - fetching data ...");
            Console.WriteLine($"Fetching data for {PumpName} pump.");
        }

        public void Update()
        {
            EventLog.WriteEntry(EventSource, $"{PumpName} pump - updating data ...");
            Console.WriteLine($"Updating data for {PumpName} pump.");
        }
    }
}