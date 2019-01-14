using System;

namespace LogAnalyzerLib.Interfaces
{
    public interface ILogger
    {
        string LastError { get; set; }

        void LogError(string message);

        event Action<string> ErrorHappend;
    }
}