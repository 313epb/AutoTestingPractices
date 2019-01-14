using System;
using LogAnalyzerLib;
using LogAnalyzerLib.FakeClasses;
using LogAnalyzerLib.Interfaces;
using NSubstitute;
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

        [Fact]
        public void Analyze_LoggerThrows_CallsWebService()
        {
            var mockWebService = Substitute.For<IWebService>();
            var stubLogger = Substitute.For<ILogger>();
            var analyzer2 = new LogAnalyzer2(mockWebService, stubLogger);
            stubLogger.When(logger=>logger.LogError(Arg.Any<string>())).Do(info=>throw new Exception("Ощибка исключение"));

            string tooShortFileName ="asd.exe";
            analyzer2.Analyze(tooShortFileName);

            mockWebService.Received().Write(Arg.Is<string>(s=>s.Contains("Ошибка")));
        }

        #endregion
    }
}