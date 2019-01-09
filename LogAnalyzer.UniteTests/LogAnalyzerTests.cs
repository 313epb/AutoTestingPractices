using System;
using LogAnalyzerLib;
using LogAnalyzerLib.Interfaces;
using Xunit;

namespace LogAnalyzer.UnitTests
{
    public class LogAnalyzerTests
    {
        #region Фабрики

        private LogAnalyzerLib.LogAnalyzer MakeAnalyzer()
        {

            return new LogAnalyzerLib.LogAnalyzer();
        }

        private LogAnalyzerLib.LogAnalyzer MakeAnalyzer(IExtensionManager extensionManager)
        {

            return new LogAnalyzerLib.LogAnalyzer(extensionManager);
        }

        #endregion

        #region Заглушки

        internal class FakeExtensionManager : IExtensionManager
        {
            public Exception WillThrow = null;
            public bool WillBeValid = false;

            public bool IsValid(string fileName)
            {
                if (WillThrow != null)
                {
                    throw WillThrow;
                }
                return WillBeValid;
            }
        }

        private FakeExtensionManager makeManager()
        {
            return  new FakeExtensionManager();
        }

        #region Внедрение заглушки через конструктор

        [Fact]
        public void IsValidLogFileName_NameSupportedExtension_ReturnsFalse()
        {
            FakeExtensionManager fakeExtension= makeManager();
            fakeExtension.WillBeValid = true;
            LogAnalyzerLib.LogAnalyzer log= MakeAnalyzer(fakeExtension);

            bool result = log.IsValidLogFileName("short.exe");

            Assert.False(result);
        }

        [Fact]
        public void IsValidLogFileName_ExtManagerThrowsException_ReturnsFalse()
        {
            FakeExtensionManager fakeExtension = makeManager();
            fakeExtension.WillThrow= new Exception("Тестовое исключение");
            LogAnalyzerLib.LogAnalyzer log = MakeAnalyzer(fakeExtension);

            bool result = false;

            try
            {
                result=log.IsValidLogFileName("short.exe");
            }
            catch (Exception e)
            {
                result = false;
            }

            Assert.False(result);
        }

        #endregion

        #region Внедрение заглушки через свойство

        [Fact]
        public void IsValidLogFileName_SupportedExtension_ReturnsTrue()
        {
            FakeExtensionManager mgr = makeManager();
            mgr.WillBeValid = true;
            LogAnalyzerLib.LogAnalyzer log = MakeAnalyzer();
            log.ExtensionManager = mgr;

            bool result = log.IsValidLogFileName("test.slf");

            Assert.True(result);
        }

        #endregion

        #endregion

        #region Тесты возвращаемых значений

        [Fact]
        public void IsValidFileName_BadExtension_ReturnsFalse()
        {
            LogAnalyzerLib.LogAnalyzer analyzer = MakeAnalyzer();

            bool result = analyzer.IsValidLogFileName("WrongName.foo");
            
            Assert.False(result);
        }

        [Fact]
        public void IsValidFileName_EmptyFileName_Throws()
        {
            LogAnalyzerLib.LogAnalyzer analyzer = MakeAnalyzer();

            var ex = Assert.Throws<ArgumentException>(() => analyzer.IsValidLogFileName(string.Empty));

            Assert.Contains("Имя файла должно быть задано.",ex.Message);
        }

        [Theory]
        [InlineData("WrongName.slf")]
        [InlineData("WrongName.SLF")]
        public void IsValidLogFileName_ValidExtensions_ReturnsTrue(string data)
        {
            LogAnalyzerLib.LogAnalyzer analyzer = MakeAnalyzer();

            bool result =analyzer.IsValidLogFileName(data);

            Assert.True(result);
        }

        #endregion

        #region Тесты состояния

        [Theory]
        [InlineData(false,"badname.foo")]
        [InlineData(true,"goodname.slf")]
        public void IsIsValidLogFileName_WhenCalled_ChangesWasLastFileNameValid(bool expected, string fileName)
        {
            LogAnalyzerLib.LogAnalyzer analyzer = MakeAnalyzer();

            analyzer.IsValidLogFileName(fileName);

            Assert.Equal(expected,analyzer.WasLastFileNameValid);
        }

        #endregion
    }
}
