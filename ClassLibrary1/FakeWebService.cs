using LogAnalyzerLib.Interfaces;

namespace LogAnalyzerLib
{
    public class FakeWebService:IWebService
    {
        public void LogError(string message)
        {
            LastError = message;
        }

        public string LastError { get; set; }
    }
}