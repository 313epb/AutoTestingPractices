using LogAnalyzerLib.Interfaces;

namespace FakeFileExtensionManager
{
    public class AlwaysValidFakeExtensionManager:IExtensionManager
    {
        public Boolean IsValid(String fileName)
        {
            return true;
        }

        public Boolean IsValid(String fileName)
        {
            throw new NotImplementedException();
        }
    }
}
