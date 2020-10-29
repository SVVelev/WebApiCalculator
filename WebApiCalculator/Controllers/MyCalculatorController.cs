using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using WebApiCalculator.ViewModels;
using WebApiCalculator.Services.Calculator;

namespace WebApiCalculator.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MyCalculatorController : ControllerBase
    {
        private readonly ICalculateService calculateService;

        private static readonly string WelcomeMessage = "Welcome to Web API Calculator";

        public MyCalculatorController(ICalculateService calculateService)
        {
            this.calculateService = calculateService;
        }

        [HttpGet]
        public WelcomeMyCalculatorViewModel Get()
        {
            WelcomeMyCalculatorViewModel viewModel = new WelcomeMyCalculatorViewModel()
            {
                Message = WelcomeMessage
            };

            return viewModel;
        }

        [HttpPost]
        public ActionResult<CalculatedResultViewModel> Post(MathExpressionViewModel expression)
        {
            string input = expression.InfixExpression;
            string calculatedResult = this.calculateService.CalculateInfixExpression(input);

            CalculatedResultViewModel viewModel = new CalculatedResultViewModel()
            {
                Result = calculatedResult
            };

            return this.Accepted(viewModel);
        }
    }
}
