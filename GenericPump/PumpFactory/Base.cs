namespace PumpFactory
{
    public class Base
    {
        private readonly string _pumpName;
        private readonly string _remoteUrl;

        public Base(string pumpName, string remoteUrl)
        {
            _pumpName = pumpName;
            _remoteUrl = remoteUrl;
        }

        public string PumpName => _pumpName;
        public string RemoteUrl => _remoteUrl;
    }
}