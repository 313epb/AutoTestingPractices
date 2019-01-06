namespace SimpleParserTests
{
    public class TestUtil
    {
        public static void ShowProblem(string test, string message)
        {
            string msg = string.Format(@"---{0}---{1}---------", test, message);
        }
    }
}