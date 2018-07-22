using P03.DependencyInversion.Contracts;

namespace P03.DependencyInversion.Models
{
    public class DivisionStrategy : ICalculationStrategy
    {
        public int Calculate(int firstOperand, int secondOperand)
        {
            return firstOperand / secondOperand;
        }
    }
}
