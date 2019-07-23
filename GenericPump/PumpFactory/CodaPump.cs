using System;

namespace PumpFactory
{
    public class CodaPump : Pump, IPumpOperation
    {
        public CodaPump(string pumpName, string remoteUrl) : base(pumpName, remoteUrl)
        {
            Console.WriteLine($"{PumpName} Pump started, fetching data from {RemoteUrl}");
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
            Console.WriteLine($"Fetching data for {PumpName}");
        }

        public void Update()
        {
            Console.WriteLine($"Updating data for {PumpName}");
        }
    }
}