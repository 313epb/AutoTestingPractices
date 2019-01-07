using Xunit;

namespace LogAnalyzer.UniteTests
{
    public class LogAnalyzerTests
    {
        [Fact]
        public void IsValidFileName_BadExtension_ReturnsFalse()
        {
            LogAnalyzerLib.LogAnalyzer analyzer = new LogAnalyzerLib.LogAnalyzer();
            bool result = analyzer.IsValidLogFileName("WrongName.foo");
            Assert.False(result);
        }
    }
}
