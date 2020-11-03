using System;
using System.Collections.Generic;
using System.Text;
using WebApiCalculator.Services.Calculator;
using Xunit;

namespace WebApiCalculator.Tests
{
    public class CalculateService_CalculateInfixExpression_Tests
    {
        private CalculateService calculateService;

        public CalculateService_CalculateInfixExpression_Tests()
        {
            this.calculateService = new CalculateService();
        }

        [Fact]
        public void CalculateInfixExpressionShouldReturnFive()
        {
            //var calculateService = new CalculateService();
            var test = "2+3";
            var actual = calculateService.CalculateInfixExpression(test);
            var expected = "5";
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void CalculateInfixExpressionShouldReturnOne()
        {
            //var calculateService = new CalculateService();
            var test = "-2+3";
            var actual = calculateService.CalculateInfixExpression(test);
            var expected = "1";
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void CalculateInfixExpressionShouldReturnMinusTwo()
        {
            //var calculateService = new CalculateService();
            var test = "2-4";
            var actual = calculateService.CalculateInfixExpression(test);
            var expected = "-2";
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void CalculateInfixExpressionShouldReturnMinusFour()
        {
            //var calculateService = new CalculateService();
            var test = "(2-4)*2";
            var actual = calculateService.CalculateInfixExpression(test);
            var expected = "-4";
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void CalculateInfixExpressionShouldReturnMinusSeven()
        {
            //var calculateService = new CalculateService();
            var test = "-2-5";
            var actual = calculateService.CalculateInfixExpression(test);
            var expected = "-7";
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void CalculateInfixExpressionShouldReturnTwo()
        {
            //var calculateService = new CalculateService();
            var test = "(2+3)-((-2)+5)";
            var actual = calculateService.CalculateInfixExpression(test);
            var expected = "2";
            Assert.Equal(expected, actual);
        }
    }
}
