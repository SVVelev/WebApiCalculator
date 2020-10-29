using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiCalculator.Services.Calculator
{
    public class CalculateService : ICalculateService
    {
        
        public string CalculateInfixExpression(string infixExpression)
        {
            try
            {
                string postfixExpression = InfixToPostfix(infixExpression);
                double result = Calculate(postfixExpression);

                return result.ToString();
            }
            catch (InvalidOperationException ex)
            {
                return ex.Message;
            }
            
        }

        private double Calculate(string postfixExpression)
        {
            Stack<double> numbers = new Stack<double>();

            for (int i = 0; i < postfixExpression.Length; i++)
            {
                if (char.IsDigit(postfixExpression[i]))
                {
                    double currentNumber = double.Parse(postfixExpression[i].ToString());
                    numbers.Push(currentNumber);
                }
                else
                {
                    char currentOperator = postfixExpression[i];

                    if (numbers.Count >= 2)
                    {
                        double firstOperand = numbers.Pop();
                        double secondOperand = numbers.Pop();

                        double result = PerformingAction(firstOperand, secondOperand, currentOperator);
                        numbers.Push(result);

                    }
                    else if (numbers.Count >= 1)
                    {
                        double firstOperand = numbers.Pop();
                        double secondOperand = 0;

                        double result = PerformingAction(firstOperand, secondOperand, currentOperator);
                        numbers.Push(result);
                    }
                }
            }

            return numbers.Pop();
        }

        private string InfixToPostfix(string infixExpression)
        {
            StringBuilder result = new StringBuilder();

            Stack<char> stack = new Stack<char>();

            if (!ParenthesesCountCorrect(infixExpression))
            {
                throw new InvalidOperationException("Invalid expression! You missed closing the bracket!");
            }

            for (int i = 0; i < infixExpression.Length; i++)
            {
                char currentSymbol = infixExpression[i];

                if (currentSymbol == ' ')
                {
                    continue;
                }

                if (char.IsDigit(currentSymbol))
                {
                    result.Append(currentSymbol);
                }
                else if (currentSymbol == '(')
                {
                    stack.Push(currentSymbol);
                }
                else if (currentSymbol == ')')
                {
                    while (stack.Count != 0 && stack.Peek() != '(')
                    {
                        result.Append(stack.Pop());
                    }

                    stack.Pop();
                }
                else
                {
                    while (stack.Count != 0 && OperatorPrecedence(currentSymbol) <= OperatorPrecedence(stack.Peek()))
                    {
                        result.Append(stack.Pop());
                    }

                    stack.Push(currentSymbol);
                }
            }

            while (stack.Count != 0)
            {
                result.Append(stack.Pop());
            }

            return result.ToString().TrimEnd();
        }

        private int OperatorPrecedence(char mathOperator)
        {
            switch (mathOperator)
            {
                case '+': return 1;
                case '-': return 1;

                case '*': return 2;
                case '/': return 2;

                case '^': return 3;
            }
            return -1;
        }

        private bool ParenthesesCountCorrect(string infixExpression)
        {
            int openBracketCount = 0;
            int closeBracketCount = 0;

            for (int i = 0; i < infixExpression.Length; i++)
            {
                if (infixExpression[i] == '(')
                {
                    openBracketCount++;
                }
                else if (infixExpression[i] == ')')
                {
                    closeBracketCount++;
                }
            }

            return openBracketCount == closeBracketCount;
        }

        private double PerformingAction(double firstOperand, double secondOperand, double mathOperator)
        {
            switch (mathOperator)
            {
                case '+': return firstOperand + secondOperand;
                case '-': return secondOperand - firstOperand;
                case '*': return firstOperand * secondOperand;
                case '/': return Math.Abs(firstOperand / secondOperand);
                case '^': return Math.Pow(firstOperand, secondOperand);
                default: throw new InvalidOperationException("Invalid expression. Operator is invalid.");
            }
        }
    }
}
