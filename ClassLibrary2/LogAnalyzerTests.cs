using NUnit.Framework;

namespace LogAnalyzer.UnitTests
{
    [TestFixture]
    public class LogAnalyzerTests
    {
        [Test]
        public void IsValidFileName_BadExtension_ReturnsFalse()
        {
            LogAnalyzerLib.LogAnalyzer analyzer = new LogAnalyzerLib.LogAnalyzer();
            bool result = analyzer.IsValidLogFileName("blabla.foo");
            Assert.False(result);
        }
    }
}
