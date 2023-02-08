namespace HalloSingelton
{
    internal class Logger
    {
        private static object _syncObj = new object();
        private static Logger _instance;
        public static Logger Instance
        {
            get
            {
                lock (_syncObj)
                {
                    if (_instance == null)
                        _instance = new Logger();
                }

                return _instance;
            }
        }

        private Logger()
        {
            Log("Logger wurde gestartet");
        }

        public void Log(string msg)
        {
            Console.WriteLine($"[{DateTime.Now:G}] {msg}");
        }
    }
}
