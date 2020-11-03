using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using WebApiCalculator.Services.Calculator;
using Xunit;

namespace WebApiCalculator.Tests
{
    public class CalculateService_ParenthesesCountCorrect_Tests
    {
        [Fact]
        public void ParenthesesCountCorrectShouldReturnTrue()
        {
            Type type = typeof(CalculateService);
            var instance = (CalculateService)Activator.CreateInstance(type);
            MethodInfo infixToPostfixMethod = type.GetMethod("ParenthesesCountCorrect", BindingFlags.NonPublic | BindingFlags.Instance);

            var test = "(2+3)*2";
            var expected = true;

            var actual = (bool)infixToPostfixMethod.Invoke(instance, new object[] { test });

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ParenthesesCountCorrectShouldReturnFalse()
        {
            Type type = typeof(CalculateService);
            var instance = (CalculateService)Activator.CreateInstance(type);
            MethodInfo infixToPostfixMethod = type.GetMethod("ParenthesesCountCorrect", BindingFlags.NonPublic | BindingFlags.Instance);

            var test = "(2+3*2";
            var expected = false;

            var actual = (bool)infixToPostfixMethod.Invoke(instance, new object[] { test });

            Assert.Equal(expected, actual);
        }
    }
}
