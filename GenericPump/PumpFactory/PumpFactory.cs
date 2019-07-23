namespace PumpFactory
{
    public class PumpFactory
    {
        private readonly Pump _pump = null;

        public PumpFactory(string pumpName, string targetUrl)
        {
            switch (pumpName.ToLower())
            {
                case "rapid":
                    _pump = new RapidPump(pumpName, targetUrl);
                    break;
                case "coda":
                    _pump = new CodaPump(pumpName, targetUrl);
                    break;
            }
        }

        public Pump GetPump()
        {
            return _pump;
        }
    }
}
