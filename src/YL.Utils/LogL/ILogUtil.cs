using System;

namespace YL.Utils.Log
{
    public interface ILogUtil
    {
        void Debug(string msg);

        void Debug(Exception exception);

        void Debug(Exception exception, string msg);

        void Info(string msg);

        void Error(string msg);

        void Fatal(string msg);

        void Trace(string msg);
    }
}