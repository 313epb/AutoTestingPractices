using LogAnalyzerLib.Interfaces;

namespace LogAnalyzerLib
{
    public class LogAnalyzerUsingFactoryMethod
    {
        public bool IsValidLogFileName(string fileName)
        {
            return GetManager().IsValid(fileName);
        }
        protected virtual IExtensionManager GetManager()
        {
            return new FileExtensionManager();
        }

        protected virtual bool IsValid(string fileName)
        {
            FileExtensionManager mgr= new FileExtensionManager();
            return mgr.IsValid(fileName);
        }
    }
}