using System;
using System.Collections.Generic;
using System.Text;
using LogAnalyzerLib;
using NUnit.Framework;

namespace LogAn.UnitTests
{
    [TestFixture]
    class LogAnalyzerTests
    {
        [Test]
        public void IsValidLogFileName_BadExtension_ReturnsFalse()
        {
            LogAnalyzer analyzer=new LogAnalyzer();
            bool result = analyzer.IsValidLogFileName("fileisbad.foo");
            Assert.False(result);
        }
    }
}
