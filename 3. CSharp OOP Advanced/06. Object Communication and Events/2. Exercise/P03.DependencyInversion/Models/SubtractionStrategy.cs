﻿using P03.DependencyInversion.Contracts;

namespace P03.DependencyInversion.Models
{
    public class SubtractionStrategy : ICalculationStrategy
    {
        public int Calculate(int firstOperand, int secondOperand)
        {
            return firstOperand - secondOperand;
        }
    }
}
