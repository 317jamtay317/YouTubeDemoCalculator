using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Calculator.Core.Calculators.Tests
{
    [TestClass()]
    public class ExpressionCalculatorTests
    {
        [TestMethod()]
        public void ShouldCalculate()
        {
            var expression = "3+3";
            var calculator = new ExpressionCalculator();

            var value = calculator.Calculate(expression);

            Assert.AreEqual(6.0, value);
        }
    }
}