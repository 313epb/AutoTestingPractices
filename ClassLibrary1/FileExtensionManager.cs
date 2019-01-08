using LogAnalyzerLib.Interfaces;

namespace LogAnalyzerLib
{
    public class FileExtensionManager:IExtensionManager
    {
        public bool IsValid(string fileName)
        {
            return true;
        }
    }
}