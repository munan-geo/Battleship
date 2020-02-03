using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship.Logger
{
    public enum LogLevel
    {
        Debug,
        Warn,
        Fatal,
        Info,
    }

    public class Log
    {
        private static Dictionary<LogLevel, NLog.LogLevel> dictLevelConversion = new Dictionary<LogLevel, NLog.LogLevel>()
        {
            { LogLevel.Debug, NLog.LogLevel.Debug },
            { LogLevel.Warn, NLog.LogLevel.Warn },
            { LogLevel.Fatal, NLog.LogLevel.Fatal },
            { LogLevel.Info, NLog.LogLevel.Info },
        };


        private static Log _instance = null;
        private static object _lock = new Object();
        private static NLog.Logger _logger = NLog.LogManager.GetLogger("Battleship");
        private Log()
        {
        }

        public static Log Logger
        {
            get
            {
                if (null == _instance)
                {
                    lock (_lock)
                    {
                        if (null == _instance)
                        {
                            _instance = new Log();
                        }
                    }
                }
                return _instance;
            }
        }

        public void Write(LogLevel level, string Message)
        {
            _logger.Log(dictLevelConversion[level], Message);
        }
    }
}
