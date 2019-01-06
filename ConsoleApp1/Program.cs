using System;

namespace SimpleParserTests
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                SimpleParserTest.TestReturnsZeroWhenEmptyString();
                Console.WriteLine("Все тесты отработали.");
                Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Console.ReadLine();
            }
        }
    }
}
