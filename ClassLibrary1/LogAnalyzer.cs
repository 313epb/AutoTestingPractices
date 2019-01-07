namespace LogAnalyzerLib
{
    public class LogAnalyzer
    {
        public bool IsValidLogFileName(string filename)
        {
            if (!filename.EndsWith(".SLF"))
            {
                return false;
            }

            return true;
        }
    }
}
