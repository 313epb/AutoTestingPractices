using System;
using LogAnalyzerLib.FakeClasses;
using LogAnalyzerLib.Interfaces;

namespace LogAnalyzerLib
{
    public class LogAnalyzer2
    {
        private readonly ILogger _logger;
        public IWebService _webService { get; set; }
        public IEmailService _emailService { get; set; }
        public int MinNameLength { get; set; } = 8;

        public LogAnalyzer2(IWebService webService, ILogger logger)
        {
            _webService = webService;
            _logger = logger;
        }
        public LogAnalyzer2(IWebService webService, IEmailService emailService)
        {
            _webService = webService;
            _emailService = emailService;
        }
        
        public void Analyze(string fileName)
        {
            if ( fileName.Length < MinNameLength)
            {
                try
                {
                     _webService?.LogError($"слишком короткое имя фаила {fileName}");
                    _logger?.LogError(string.Format("слишком короткое имя фаила {0}", fileName));
                }
                catch (Exception e)
                {
                    _emailService?.SendEmail("кто-то","не могу",e.Message);
                    _webService?.Write($"Ошибка регистратора {e.Message}");
                }
            }
        }
    }
}

