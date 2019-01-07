using System;

namespace LogAnalyzerLib
{
    public class LogAnalyzer
    {
        public bool IsValidLogFileName(string filename)
        {
            if (!filename.EndsWith(".SLF",StringComparison.CurrentCultureIgnoreCase))
            {
                return false;
            }
            return true;
        }
    }
}
