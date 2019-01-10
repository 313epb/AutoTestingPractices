using System;
using LogAnalyzerLib;
using Xunit;

namespace LogAnalyzer.UnitTests
{
    public class LogAnalyzer2Tests
    {

        #region Заглушка + Мок

        [Fact]
        public void Analyze_WebServiceThrows_SendsEmail()
        {
            FakeWebService stubService = new FakeWebService();
            stubService.ToThrow = new Exception("fake Exeption");
            FakeEmailService mockEmail = new FakeEmailService();
            LogAnalyzer2 log = new LogAnalyzer2(stubService, mockEmail);
            string tooShortFileName = "abc.tt";

            log.Analyze(tooShortFileName);

            Assert.Contains("fake Exeption", mockEmail.Body);
            Assert.Contains("не могу", mockEmail.Subject);
            Assert.Contains("кто-то", mockEmail.To);
        }

        #endregion
    }
}