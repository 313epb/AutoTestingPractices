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
        [Category("Быстрые тесты")]
        [Fact]
        public void IsValidFileName_BadExtension_ReturnsFalse()
        {
            LogAnalyzerLib.LogAnalyzer analyzer = MakeAnalyzer();

            bool result = analyzer.IsValidLogFileName("WrongName.foo");
            
            Assert.False(result);
        }

        [Category("Быстрые тесты")]
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
    }
}
