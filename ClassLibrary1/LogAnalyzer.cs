using System;

namespace LogAnalyzerLib
{
    public class LogAnalyzer
    {
        public bool IsValidLogFileName(string filename)
        {
            if (string.IsNullOrEmpty(filename))
            {
                throw new ArgumentException("Имя файла должно быть задано.");
            }

            if (!filename.EndsWith(".SLF",StringComparison.CurrentCultureIgnoreCase))
            {
                return false;
            }

            return true;
        }
    }
}
