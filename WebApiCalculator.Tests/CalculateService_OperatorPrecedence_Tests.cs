using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using WebApiCalculator.Services.Calculator;
using Xunit;

namespace WebApiCalculator.Tests
{
    public class CalculateService_OperatorPrecedence_Tests
    {
        [Fact]
        public void OperatorPrecedenceShouldReturnOneTestedWithPlus()
        {
            Type type = typeof(CalculateService);
            var instance = (CalculateService)Activator.CreateInstance(type);
            MethodInfo infixToPostfixMethod = type.GetMethod("OperatorPrecedence", BindingFlags.NonPublic | BindingFlags.Instance);

            var test = '+';
            var expected = 1;

            var actual = (int)infixToPostfixMethod.Invoke(instance, new object[] { test });

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void OperatorPrecedenceShouldReturnOneTestedWithMinus()
        {
            Type type = typeof(CalculateService);
            var instance = (CalculateService)Activator.CreateInstance(type);
            MethodInfo infixToPostfixMethod = type.GetMethod("OperatorPrecedence", BindingFlags.NonPublic | BindingFlags.Instance);

            var test = '-';
            var expected = 1;

            var actual = (int)infixToPostfixMethod.Invoke(instance, new object[] { test });

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void OperatorPrecedenceShouldReturnTwoTestedWithMultiplication()
        {
            Type type = typeof(CalculateService);
            var instance = (CalculateService)Activator.CreateInstance(type);
            MethodInfo infixToPostfixMethod = type.GetMethod("OperatorPrecedence", BindingFlags.NonPublic | BindingFlags.Instance);

            var test = '*';
            var expected = 2;

            var actual = (int)infixToPostfixMethod.Invoke(instance, new object[] { test });

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void OperatorPrecedenceShouldReturnTwoTestedWithDivision()
        {
            Type type = typeof(CalculateService);
            var instance = (CalculateService)Activator.CreateInstance(type);
            MethodInfo infixToPostfixMethod = type.GetMethod("OperatorPrecedence", BindingFlags.NonPublic | BindingFlags.Instance);

            var test = '/';
            var expected = 2;

            var actual = (int)infixToPostfixMethod.Invoke(instance, new object[] { test });

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void OperatorPrecedenceShouldReturnTwoTestedWithGrading()
        {
            Type type = typeof(CalculateService);
            var instance = (CalculateService)Activator.CreateInstance(type);
            MethodInfo infixToPostfixMethod = type.GetMethod("OperatorPrecedence", BindingFlags.NonPublic | BindingFlags.Instance);

            var test = '^';
            var expected = 3;

            var actual = (int)infixToPostfixMethod.Invoke(instance, new object[] { test });

            Assert.Equal(expected, actual);
        }
    }
}
