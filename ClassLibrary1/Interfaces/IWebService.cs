namespace LogAnalyzerLib.Interfaces
{
    public interface IWebService
    {
        void LogError(string message);
        void Write(string message);
    }
}