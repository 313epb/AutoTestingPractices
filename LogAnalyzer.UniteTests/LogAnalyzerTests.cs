using Xunit;

namespace LogAnalyzer.UniteTests
{
    public class LogAnalyzerTests
    {
        [Fact]
        public void IsValidFileName_BadExtension_ReturnsFalse()
        {
            //Arrange
            LogAnalyzerLib.LogAnalyzer analyzer = new LogAnalyzerLib.LogAnalyzer();
            //Act
            bool result = analyzer.IsValidLogFileName("WrongName.foo");
            //Assert
            Assert.False(result);
        }

        [Theory]
        [InlineData("WrongName.slf")]
        [InlineData("WrongName.SLF")]
        public void IsValidLogFileName_ValidExtensions_ReturnsTrue(string data)
        {
            //Arrange
            LogAnalyzerLib.LogAnalyzer analyzer = new LogAnalyzerLib.LogAnalyzer();
            //Act
            bool result =analyzer.IsValidLogFileName(data);
            //Assert
            Assert.True(result);
        }
    }
}
