using System;
using LogAnalyzerLib;
using LogAnalyzerLib.Interfaces;
using Xunit;

namespace LogAnalyzer.UnitTests
{
    public class LogAnalyzerTests
    {
        #region �������

        private LogAnalyzerLib.LogAnalyzer MakeAnalyzer()
        {

            return new LogAnalyzerLib.LogAnalyzer();
        }

        private LogAnalyzerLib.LogAnalyzer MakeAnalyzer(IWebService webService)
        {
            return new LogAnalyzerLib.LogAnalyzer(webService);
        }

        private LogAnalyzerLib.LogAnalyzer MakeAnalyzer(IExtensionManager extensionManager)
        {

            return new LogAnalyzerLib.LogAnalyzer(extensionManager);
        }

        #endregion

        #region ��������

        internal class FakeExtensionManager : IExtensionManager
        {
            public Exception WillThrow;
            public bool WillBeValid ;

            public bool IsValid(string fileName)
            {
                if (WillThrow != null)
                {
                    throw WillThrow;
                }
                return WillBeValid;
            }
        }

        private FakeExtensionManager MakeManager()
        {
            return  new FakeExtensionManager();
        }

        #region ��������� �������� ����� �����������

        [Fact]
        public void IsValidLogFileName_NameSupportedExtension_ReturnsFalse()
        {
            FakeExtensionManager fakeExtension= MakeManager();
            fakeExtension.WillBeValid = true;
            LogAnalyzerLib.LogAnalyzer log= MakeAnalyzer(fakeExtension);

            bool result = log.IsValidLogFileName("short.exe");

            Assert.False(result);
        }

        [Fact]
        public void IsValidLogFileName_ExtManagerThrowsException_ReturnsFalse()
        {
            FakeExtensionManager fakeExtension = MakeManager();
            fakeExtension.WillThrow= new Exception("�������� ����������");
            LogAnalyzerLib.LogAnalyzer log = MakeAnalyzer(fakeExtension);

            bool result;

            try
            {
                result=log.IsValidLogFileName("short.exe");
            }
            catch (Exception)
            {
                result = false;
            }

            Assert.False(result);
        }

        #endregion

        #region ��������� �������� ����� ��������

        [Fact]
        public void IsValidLogFileName_SupportedExtension_ReturnsTrue()
        {
            FakeExtensionManager mgr = MakeManager();
            mgr.WillBeValid = true;
            LogAnalyzerLib.LogAnalyzer log = MakeAnalyzer();
            log.ExtensionManager = mgr;

            bool result = log.IsValidLogFileName("test.slf");

            Assert.True(result);
        }

        #endregion

        #region �������� ���������� ������ � ����������� ������

        internal class TestableLogAnalyzer:LogAnalyzerUsingFactoryMethod
        {
            public IExtensionManager _extensionManager;

            public TestableLogAnalyzer(IExtensionManager extensionManager)
            {
                _extensionManager = extensionManager;
            }

            protected override IExtensionManager GetManager()
            {
                return _extensionManager;
            }
        }

        [Fact]
        public void IsValidLogFileName_UnsupportedExtension_ReturnsFalse()
        {
            FakeExtensionManager mgr = MakeManager();
            mgr.WillBeValid = false;

            TestableLogAnalyzer log=new TestableLogAnalyzer(mgr);

            bool result = log.IsValidLogFileName("factory.ght");

            Assert.False(result);
        }

        #endregion

        #region ����������� ����������� ���������� � �����

        internal class TestableLogAnalyzerResult : LogAnalyzerUsingFactoryMethod
        {
            public bool IsSupported;

            protected override bool IsValid(string fileName)
            {
                return IsSupported;
            }
        }

        [Fact]
        public void IsValidLogFileName_FakeLogResult_AlwaysReturnsTrue()
        {
            TestableLogAnalyzerResult log= new TestableLogAnalyzerResult();
            log.IsSupported = true;

            bool result = log.IsValidLogFileName("context.amr");

            Assert.True(result);

        }

        #endregion

        #region ������������ ����� mock(���������� ������)  

        [Fact]
        public void Analyze_TooShortFileName_CallsWebService()
        {
            FakeWebService mockService = new FakeWebService();
            LogAnalyzerLib.LogAnalyzer log = MakeAnalyzer(mockService);
            string tooShortFileName ="abc.ext";

            log.Analyze(tooShortFileName);

            Assert.Contains("������� �������� ��� �����",mockService.LastError);
        }

        #endregion

        #endregion

        #region ����� ������������ ��������

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

            Assert.Contains("��� ����� ������ ���� ������.",ex.Message);
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

        #region ����� ���������

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
