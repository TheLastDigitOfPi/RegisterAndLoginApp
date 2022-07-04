using NLog;

namespace RegisterAndLoginApp.Utility
{
    public class MyLogger : IloggerNew
    {
        public static MyLogger Instance { get; private set; }
        public static Logger logger;

        public static MyLogger GetInstance()
        {
            if (Instance == null)
                Instance = new MyLogger();
            return Instance;
        }

        private Logger GetLogger()
        {
            if (MyLogger.logger == null)
                MyLogger.logger = LogManager.GetLogger("LoginAppLoggerrule");
            return MyLogger.logger;
        }

        public void Debug(string message)
        {
            GetLogger().Debug(message);
        }

        public void Error(string message)
        {
            GetLogger().Error(message);
        }

        public void Info(string message)
        {
            GetLogger().Info(message);
        }

        public void Warning(string message)
        {
            GetLogger().Warn(message);
        }
    }
}
