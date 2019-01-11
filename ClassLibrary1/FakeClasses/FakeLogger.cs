using System;
using LogAnalyzerLib.Interfaces;

namespace LogAnalyzerLib.FakeClasses
{
    public class FakeLogger : ILogger
    {
        public string LastError { get; set; }

        public void LogError(string message)
        {
            LastError = message;
        }
    }
}