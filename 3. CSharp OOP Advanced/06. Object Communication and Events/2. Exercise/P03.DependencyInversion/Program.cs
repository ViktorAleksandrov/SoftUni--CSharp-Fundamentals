using System;
using P03.DependencyInversion.Contracts;
using P03.DependencyInversion.Models;

namespace P03.DependencyInversion
{
    class Program
    {
        static void Main(string[] args)
        {
            var calculator = new PrimitiveCalculator();

            string input;

            while ((input = Console.ReadLine()) != "End")
            {
                string[] inputArgs = input.Split();

                if (inputArgs[0] == "mode")
                {
                    char @operator = inputArgs[1][0];

                    ICalculationStrategy strategy = null;

                    switch (@operator)
                    {
                        case '+':
                            strategy = new AdditionStrategy();
                            break;
                        case '-':
                            strategy = new SubtractionStrategy();
                            break;
                        case '*':
                            strategy = new MultiplicationStrategy();
                            break;
                        case '/':
                            strategy = new DivisionStrategy();
                            break;
                    }

                    calculator.ChangeStrategy(strategy);
                }
                else
                {
                    int firstOperand = int.Parse(inputArgs[0]);
                    int secondOperand = int.Parse(inputArgs[1]);

                    int result = calculator.PerformCalculation(firstOperand, secondOperand);

                    Console.WriteLine(result);
                }
            }
        }
    }
}
