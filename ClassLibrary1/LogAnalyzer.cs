using System;
using LogAnalyzerLib.Interfaces;

namespace LogAnalyzerLib
{
    public class LogAnalyzer
    {
        private readonly IExtensionManager _extensionManager;
        public bool WasLastFileNameValid { get; set; }

        public LogAnalyzer(IExtensionManager extensionManager)
        {
            _extensionManager = extensionManager;
        }

        public LogAnalyzer()
        {

        }

        public bool IsValidLogFileName(string filename)
        {
            WasLastFileNameValid = false;

            if (_extensionManager!=null)return _extensionManager.IsValid(filename);

            if (string.IsNullOrEmpty(filename))
            {
                throw new ArgumentException("Имя файла должно быть задано.");
            }

            if (!filename.EndsWith(".SLF", StringComparison.CurrentCultureIgnoreCase))
            {
                return false;
            }

            WasLastFileNameValid = true;
            return true;
        }
    }
}
