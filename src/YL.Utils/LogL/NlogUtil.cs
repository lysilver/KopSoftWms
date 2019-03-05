using NLog;
using System;

namespace YL.Utils.Log
{
    public class NlogUtil : ILogUtil
    {
        private readonly Logger _logger = LogManager.GetCurrentClassLogger();

        public void Debug(string msg)
        {
            _logger.Debug(msg);
        }

        public void Debug(Exception exception, string msg)
        {
            _logger.Debug(exception, msg);
        }

        public void Debug(Exception exception)
        {
            _logger.Debug(exception);
        }

        public void Error(string msg)
        {
            _logger.Error(msg);
        }

        public void Fatal(string msg)
        {
            _logger.Fatal(msg);
        }

        public void Info(string msg)
        {
            _logger.Info(msg);
        }

        public void Trace(string msg)
        {
            _logger.Trace(msg);
        }
    }
}