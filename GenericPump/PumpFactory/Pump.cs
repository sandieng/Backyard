namespace PumpFactory
{
    public abstract class Pump 
    {
        private readonly string _pumpName;
        private readonly string _remoteUrl;

        public string PumpName => _pumpName;
        public string RemoteUrl => _remoteUrl;

        protected Pump(string pumpName, string remoteUrl)
        {
            _pumpName = pumpName;
            _remoteUrl = remoteUrl;
        }

        public abstract void Start();
    }
}