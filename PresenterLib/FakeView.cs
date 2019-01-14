using System;
using System.Runtime.InteropServices.ComTypes;

namespace PresenterLib
{
    public class FakeView:IView
    {
        public event Action Loaded;
        public event Action<string> ErrorOccured;
        public void Render(string text)
        {
            Loaded.Invoke();
        }
    }
}