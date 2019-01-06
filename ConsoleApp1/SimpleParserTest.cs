using System;
using System.Reflection;


namespace SimpleParserTests
{
    class SimpleParserTest
    {
        public static void TestReturnsZeroWhenEmptyString()
        {
            string testname = MethodBase.GetCurrentMethod().Name;
            try
            {
                SimpleParser.SimpleParser p= new SimpleParser.SimpleParser();
                int result = p.ParseAndSum(string.Empty);
                if (result!=0)
                {
                    TestUtil.ShowProblem(testname,@"ParseAndSum должен вернуть 0 для пустой строки");
                }
            }
            catch (Exception e)
            {
                TestUtil.ShowProblem(testname,e.ToString());
            }
        }
    }
}
