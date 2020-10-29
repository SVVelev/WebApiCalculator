using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiCalculator.Services.Calculator
{
   public interface ICalculateService
    {
        string CalculateInfixExpression(string input);    
    }
}
