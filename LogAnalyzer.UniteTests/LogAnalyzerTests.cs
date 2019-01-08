using System;
using System.ComponentModel;
using Xunit;

namespace LogAnalyzer.UniteTests
{
    public class LogAnalyzerTests
    {
        private LogAnalyzerLib.LogAnalyzer MakeAnalyzer()
        {
            return new LogAnalyzerLib.LogAnalyzer();
        }

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
