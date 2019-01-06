using System;

namespace SimpleParser
{
    public class SimpleParser
    {
        public int ParseAndSum(string numbers)
        {
            if (numbers.Length == 0)
            {
                return 0;
            }
            if (!numbers.Contains(","))
            {
                return int.Parse(numbers);
            }
            else
            {
                throw new InvalidOperationException("Пока умею обрабатывать только числа 0 и 1!" );
            }
        }
    }
}
