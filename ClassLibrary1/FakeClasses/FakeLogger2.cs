using System;
using LogAnalyzerLib.Interfaces;

namespace LogAnalyzerLib.FakeClasses
{
    public class FakeLogger2:ILogger
    {
        public Exception WillThrow = null;
        public string LoggerGotMessage = null;
        public string LastError { get; set; }

        public void LogError(string message)
        {
            LoggerGotMessage = message;
            if (WillThrow != null)
            {
                throw WillThrow;
            }
        }

        public event Action<string> ErrorHappend;
    }
}