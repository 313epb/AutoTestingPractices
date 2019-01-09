using System;
using System.Reflection;
using LogAnalyzerLib.Interfaces;

namespace LogAnalyzerLib
{
    public class LogAnalyzer
    {
        private IExtensionManager _extensionManager;
        
        public IExtensionManager ExtensionManager{get => _extensionManager; set => _extensionManager = value;}

        public bool WasLastFileNameValid { get; set; }

        public LogAnalyzer(IExtensionManager extensionManager)
        {
            _extensionManager = extensionManager;
        }

        public LogAnalyzer()
        {
            ExtensionManagerFactory factory= new ExtensionManagerFactory();
            _extensionManager = factory.Create();
        }

        public bool IsValidLogFileName(string filename)
        {
            WasLastFileNameValid = false;

            //строка для тестирования внедрения зависимостей, дабы не переписывать класс. 
            //if (_extensionManager != null) return _extensionManager.IsValid(filename);

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
