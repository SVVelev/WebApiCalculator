using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using WebApiCalculator.Services.Calculator;
using Xunit;

namespace WebApiCalculator.Tests
{
    public class CalculateService_Calculate_Tests
    {
        [Fact]
        public void CalculateShouldReturnMinusTwo()
        {
            Type type = typeof(CalculateService);
            var instance = (CalculateService)Activator.CreateInstance(type);
            MethodInfo infixToPostfixMethod = type.GetMethod("Calculate", BindingFlags.NonPublic | BindingFlags.Instance);

            var test = "24-";
            var expected = -2;

            var actual = (double)infixToPostfixMethod.Invoke(instance, new object[] { test });

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void CalculateShouldReturnFive()
        {
            Type type = typeof(CalculateService);
            var instance = (CalculateService)Activator.CreateInstance(type);
            MethodInfo infixToPostfixMethod = type.GetMethod("Calculate", BindingFlags.NonPublic | BindingFlags.Instance);

            var test = "23+";
            var expected = 5;

            var actual = (double)infixToPostfixMethod.Invoke(instance, new object[] { test });

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void CalculateShouldReturnMinusFour()
        {
            Type type = typeof(CalculateService);
            var instance = (CalculateService)Activator.CreateInstance(type);
            MethodInfo infixToPostfixMethod = type.GetMethod("Calculate", BindingFlags.NonPublic | BindingFlags.Instance);

            var test = "24-2*";
            var expected = -4;

            var actual = (double)infixToPostfixMethod.Invoke(instance, new object[] { test });

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void CalculateShouldReturnOne()
        {
            Type type = typeof(CalculateService);
            var instance = (CalculateService)Activator.CreateInstance(type);
            MethodInfo infixToPostfixMethod = type.GetMethod("Calculate", BindingFlags.NonPublic | BindingFlags.Instance);

            var test = "2-3+";
            var expected = 1;

            var actual = (double)infixToPostfixMethod.Invoke(instance, new object[] { test });

            Assert.Equal(expected, actual);
        }
    }
}
