namespace LogAnalyzerLib.Interfaces
{
    public interface ILogger
    {
        string LastError { get; set; }

        void LogError(string message);
    }
}