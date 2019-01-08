using Xunit;

namespace MemCalculator.UnitTests
{
    public class MemCalculatorTetsts
    {
        private MemCalculatorLib.MemCalculator MakeCalc()
        {
            return  new MemCalculatorLib.MemCalculator();
        }

        [Fact]
        public void Sum_ByDefault_ReturnsZero()
        {
            MemCalculatorLib.MemCalculator calculator = MakeCalc();

            int result = calculator.Sum();

            Assert.Equal(0,result);
        }

        [Fact]
        public void Add_WhenCalled_ChangesSum()
        {
            MemCalculatorLib.MemCalculator calculator = MakeCalc();

            calculator.Add(1);
            int sum = calculator.Sum();

            Assert.Equal(1,sum);
        }
    }
}
