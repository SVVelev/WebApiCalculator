using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using WebApiCalculator.Services.Calculator;
using Xunit;

namespace WebApiCalculator.Tests
{
    public class CalculateService_PerformingAction_Tests
    {
        [Fact]
        public void PerformingActionShouldReturnFive()
        {
            Type type = typeof(CalculateService);
            var instance = (CalculateService)Activator.CreateInstance(type);
            MethodInfo infixToPostfixMethod = type.GetMethod("PerformingAction", BindingFlags.NonPublic | BindingFlags.Instance);

            double firstOperand = 2;
            double secondOperand = 3;
            char mathOperator = '+';

            var expected = 5;

            var actual = (double)infixToPostfixMethod.Invoke(instance, new object[] { firstOperand, secondOperand, mathOperator });

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void PerformingActionShouldReturnTwo()
        {
            Type type = typeof(CalculateService);
            var instance = (CalculateService)Activator.CreateInstance(type);
            MethodInfo infixToPostfixMethod = type.GetMethod("PerformingAction", BindingFlags.NonPublic | BindingFlags.Instance);

            double firstOperand = 3;
            double secondOperand = 5;
            char mathOperator = '-';

            var expected = 2;

            var actual = (double)infixToPostfixMethod.Invoke(instance, new object[] { firstOperand, secondOperand, mathOperator });

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void PerformingActionShouldReturnFour()
        {
            Type type = typeof(CalculateService);
            var instance = (CalculateService)Activator.CreateInstance(type);
            MethodInfo infixToPostfixMethod = type.GetMethod("PerformingAction", BindingFlags.NonPublic | BindingFlags.Instance);

            double firstOperand = 2;
            double secondOperand = 2;
            char mathOperator = '*';

            var expected = 4;

            var actual = (double)infixToPostfixMethod.Invoke(instance, new object[] { firstOperand, secondOperand, mathOperator });

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void PerformingActionShouldReturnThree()
        {
            Type type = typeof(CalculateService);
            var instance = (CalculateService)Activator.CreateInstance(type);
            MethodInfo infixToPostfixMethod = type.GetMethod("PerformingAction", BindingFlags.NonPublic | BindingFlags.Instance);

            double firstOperand = 12;
            double secondOperand = 4;
            char mathOperator = '/';

            var expected = 3;

            var actual = (double)infixToPostfixMethod.Invoke(instance, new object[] { firstOperand, secondOperand, mathOperator });

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void PerformingActionShouldReturnNine()
        {
            Type type = typeof(CalculateService);
            var instance = (CalculateService)Activator.CreateInstance(type);
            MethodInfo infixToPostfixMethod = type.GetMethod("PerformingAction", BindingFlags.NonPublic | BindingFlags.Instance);

            double firstOperand = 3;
            double secondOperand = 2;
            char mathOperator = '^';

            var expected = 9;

            var actual = (double)infixToPostfixMethod.Invoke(instance, new object[] { firstOperand, secondOperand, mathOperator });

            Assert.Equal(expected, actual);
        }
    }
}
