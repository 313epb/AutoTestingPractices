using System;
using System.Runtime.CompilerServices;
using LogAnalyzerLib.Factories;
using LogAnalyzerLib.Interfaces;
[assembly: InternalsVisibleToAttribute("LogAnalyzer.UnitTests")]

namespace LogAnalyzerLib
{
    public class LogAnalyzer
    {
        private readonly ILogger _logger;
        private readonly IWebService _webService;
        private IExtensionManager _extensionManager;
        public int MinNameLength=8;
        
        public IExtensionManager ExtensionManager{get => _extensionManager; set => _extensionManager = value;}

        public bool WasLastFileNameValid { get; set; }

        internal LogAnalyzer(IExtensionManager extensionManager)
        {
            _extensionManager = extensionManager;

        }

        public LogAnalyzer()
        {
            
        }

        public LogAnalyzer(ILogger logger)
        {
            _logger = logger;
        }


        public LogAnalyzer(IWebService webService)
        {
            _webService = webService;
        }

        public void Analyze(string fileName)
        {
            if (fileName.Length < MinNameLength)
            {
                if (_webService!=null)
                {
                    _webService.LogError($"слишком короткое имя файла - {fileName}");
                }

                if (_logger != null) 
                {
                    _logger.LastError= $"слишком короткое имя файла - {fileName}";
                }

                //LoggingFacility.Log($"Слишком короткое имя файла - {fileName}") ;
            }
            
        }


        public LogAnalyzer(ExtensionManagerFactory factory)
        {
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
