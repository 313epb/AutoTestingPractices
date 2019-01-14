using System;

namespace PresenterLib
{
    public interface IView
    {
        event Action Loaded;
        event Action<string> ErrorOccured;
        void Render(string text);
        
    }
}