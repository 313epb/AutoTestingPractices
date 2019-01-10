using System;
using LogAnalyzerLib.Interfaces;

namespace LogAnalyzerLib
{
    public class LogAnalyzer2
    {
        public IWebService _webService { get; set; }
        public IEmailService _emailService { get; set; }

        public LogAnalyzer2(IWebService webService, IEmailService emailService)
        {
            _webService = webService;
            _emailService = emailService;
        }
        
        public void Analyze(string fileName)
        {
            if ( fileName.Length < 8)
            {
                try
                {
                    _webService.LogError($"слишком короткое имя фаила {fileName}");
                }
                catch (Exception e)
                {
                    _emailService.SendEmail("кто-то","не могу",e.Message);
                }
            }
        }
    }
}