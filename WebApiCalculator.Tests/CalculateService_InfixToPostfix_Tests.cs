using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using WebApiCalculator.Services.Calculator;
using Xunit;

namespace WebApiCalculator.Tests
{
    public class CalculateService_InfixToPostfix_Tests
    {

        [Fact]
        public void InfixToPostfixShouldREturnTwoMinusThreePlus()
        {
            Type type = typeof(CalculateService);
            var instance = (CalculateService)Activator.CreateInstance(type);
            MethodInfo infixToPostfixMethod = type.GetMethod("InfixToPostfix", BindingFlags.NonPublic | BindingFlags.Instance);

            var test = "-2+3";
            var expected = "2-3+";

            var actual = (string)infixToPostfixMethod.Invoke(instance, new object[] { test });

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void InfixToPostfixShouldReturnTwoFourMinus()
        {
            Type type = typeof(CalculateService);
            var instance = (CalculateService)Activator.CreateInstance(type);
            MethodInfo infixToPostfixMethod = type.GetMethod("InfixToPostfix", BindingFlags.NonPublic | BindingFlags.Instance);

            var test = "2-4";
            var expected = "24-";

            var actual = (string)infixToPostfixMethod.Invoke(instance, new object[] { test });

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void InfixToPostfixShouldReturnTwoThreePlus()
        {
            Type type = typeof(CalculateService);
            var instance = (CalculateService)Activator.CreateInstance(type);
            MethodInfo infixToPostfixMethod = type.GetMethod("InfixToPostfix", BindingFlags.NonPublic | BindingFlags.Instance);

            var test = "2+3";
            var expected = "23+";

            var actual = (string)infixToPostfixMethod.Invoke(instance, new object[] { test });

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void InfixToPostfixShouldReturnTwoFourMinusTwoMultiplication()
        {
            Type type = typeof(CalculateService);
            var instance = (CalculateService)Activator.CreateInstance(type);
            MethodInfo infixToPostfixMethod = type.GetMethod("InfixToPostfix", BindingFlags.NonPublic | BindingFlags.Instance);

            var test = "(2-4)*2";
            var expected = "24-2*";

            var actual = (string)infixToPostfixMethod.Invoke(instance, new object[] { test });

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void InfixToPostfixShouldThrowExceptionMissingClosingBracket()
        {
            Type type = typeof(CalculateService);
            var instance = (CalculateService)Activator.CreateInstance(type);
            MethodInfo infixToPostfixMethod = type.GetMethod("InfixToPostfix", BindingFlags.NonPublic | BindingFlags.Instance);

            var test = "(2-4*2";

            var ex = Assert.Throws<TargetInvocationException>(() => infixToPostfixMethod.Invoke(instance, new object[] { test }));

            Assert.Equal("Invalid expression! You missed closing the bracket!", ex.InnerException.Message);
        }

        [Fact]
        public void InfixToPostfixShouldThrowExceptionOnlyNumbersAreAlowed()
        {
            Type type = typeof(CalculateService);
            var instance = (CalculateService)Activator.CreateInstance(type);
            MethodInfo infixToPostfixMethod = type.GetMethod("InfixToPostfix", BindingFlags.NonPublic | BindingFlags.Instance);

            var test = "hello";

            var ex = Assert.Throws<TargetInvocationException>(() => infixToPostfixMethod.Invoke(instance, new object[] { test }));

            Assert.Equal("Only numbers are alowed!", ex.InnerException.Message);
        }

        [Fact]
        public void InfixToPostfixShouldThrowExceptionDoubleNumbersAreNotAlowed()
        {
            Type type = typeof(CalculateService);
            var instance = (CalculateService)Activator.CreateInstance(type);
            MethodInfo infixToPostfixMethod = type.GetMethod("InfixToPostfix", BindingFlags.NonPublic | BindingFlags.Instance);

            var test = "2.3+4";

            var ex = Assert.Throws<TargetInvocationException>(() => infixToPostfixMethod.Invoke(instance, new object[] { test }));

            Assert.Equal("Double numbers are not alowed!", ex.InnerException.Message);
        }

    }
}
