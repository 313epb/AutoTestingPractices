using System;

namespace LogAnalyzerLib
{
    public class LogAnalyzer
    {
        public bool WasLastFileNameValid { get; set; }

        public bool IsValidLogFileName(string filename)
        {
            WasLastFileNameValid = false;

            if (string.IsNullOrEmpty(filename))
            {
                throw new ArgumentException("Имя файла должно быть задано.");
            }

            if (!filename.EndsWith(".SLF",StringComparison.CurrentCultureIgnoreCase))
            {
                return false;
            }

            WasLastFileNameValid = true;
            return true;
        }
    }
}
