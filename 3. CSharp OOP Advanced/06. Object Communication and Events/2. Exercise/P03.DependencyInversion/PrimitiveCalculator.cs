using P03.DependencyInversion.Contracts;
using P03.DependencyInversion.Models;

namespace P03.DependencyInversion
{
    public class PrimitiveCalculator
    {
        private ICalculationStrategy currentStrategy;

        public PrimitiveCalculator()
        {
            this.currentStrategy = new AdditionStrategy();
        }

        public void ChangeStrategy(ICalculationStrategy strategy)
        {
            this.currentStrategy = strategy;
        }

        public int PerformCalculation(int firstOperand, int secondOperand)
        {
            int result = this.currentStrategy.Calculate(firstOperand, secondOperand);

            return result;
        }
    }
}
