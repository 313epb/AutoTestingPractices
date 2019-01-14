using LogAnalyzerLib.Interfaces;

namespace PresenterLib
{
    public class Presenter
    {
        private readonly ILogger _logger;
        private readonly IView _view;

        public Presenter(IView view)
        {
            _view = view;
            _view.Loaded += OnLoaded;
        }

        public Presenter(IView view,ILogger logger)
        {
            _logger = logger;
            _view = view;
            _view.ErrorOccured += ErrorHappend;
        }

        private void OnLoaded()
        {
            _view.Render("HelloWorld");
        }

        private void ErrorHappend(string message)
        {
            _logger.LogError(message);
        }
    }
}