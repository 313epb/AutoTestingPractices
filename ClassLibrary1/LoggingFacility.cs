
using LogAnalyzerLib.Interfaces;

namespace LogAnalyzerLib
{
    public static class LoggingFacility
    {
        private static ILogger _logger;

        private static ILogger Logger{get => _logger;set => _logger = value;}

        public static void Log(string text)
        {
            _logger.LogError(text);
        }
    }
}