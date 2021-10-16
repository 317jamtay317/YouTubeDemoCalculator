using System;
using System.Data;

namespace Calculator.Core.Calculators
{
    public class ExpressionCalculator:ICalculator
    {
        public double Calculate(string expresstion)
        {
            var dataTable = new DataTable();
            var value = dataTable.Compute(expresstion, string.Empty);

            return Convert.ToDouble(value);
        }
    }
}