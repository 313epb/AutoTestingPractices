using System;
using LogAnalyzerLib.Interfaces;
using NSubstitute;
using PresenterLib;
using Xunit;

namespace Presenter.UnitTests
{
    public class PresenterTests
    {
        [Fact]
        public void ctor_WheViewIsLoaded_CallsViewRender()
        {
            var mock = Substitute.For<IView>();

            PresenterLib.Presenter p= new PresenterLib.Presenter(mock);
            mock.Loaded += Raise.Event<Action>();

            mock.Received().Render(Arg.Is<string>(s=>s.Contains("HelloWorld")));
        }

        [Fact]
        public void ctor_WhenViewhasError_CallsLogger()
        {
            var stubView = Substitute.For<IView>();
            var mockLogger = Substitute.For<ILogger>();
            PresenterLib.Presenter p = new PresenterLib.Presenter(stubView, mockLogger);
            stubView.ErrorOccured +=Raise.Event<Action<string>>("fake error");
            mockLogger.Received()
                .LogError(Arg.Is<string>(s => s.Contains("fake error")));
        }

        [Fact]
        public void IView_Loaded_FiringManual()
        {
            bool loadFired=false;
            IView view= new FakeView();
            view.Loaded += () => loadFired = true;

            view.Render("try");
            
            Assert.True(loadFired);
        }
    }
}