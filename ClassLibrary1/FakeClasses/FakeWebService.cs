using System;
using LogAnalyzerLib.Interfaces;

namespace LogAnalyzerLib.FakeClasses
{
    public class FakeWebService:IWebService
    {
        public Exception ToThrow { get; set; }
        public string LastError { get; set; }

        public void LogError(string message)
        {
            LastError = message;
            if (ToThrow != null)
            {
                throw ToThrow;
            }
        }

        public string MessageToWebService { get; set; }

        public void Write(string message)
        {
            MessageToWebService = message;
        }

    }
}