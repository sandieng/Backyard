namespace PumpFactory
{
    public class PumpFactory
    {
        private readonly Pump _pump = null;

        public PumpFactory(string pumpName, string targetUrl, string eventSource)
        {
            switch (pumpName.ToLower())
            {
                case "rapid":
                    _pump = new RapidPump(pumpName, targetUrl, eventSource);
                    break;
                case "coda":
                    _pump = new CodaPump(pumpName, targetUrl, eventSource);
                    break;
            }
        }

        public Pump GetPump()
        {
            return _pump;
        }
    }
}
