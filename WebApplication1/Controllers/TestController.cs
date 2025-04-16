using ClassLibrary1;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class TestController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Greet(string name)
        {
            return Content($"Привет {name}!");
        }

        public IActionResult UserInfo()
        {
            var user = new User { Name="Олежа Богатырь", Age=30 };
            return View(user);
        }

        public IActionResult Calculator(double num1, double num2, string op)
        {
            try
            {
                Calculator calculator = new Calculator();
                double result;
                switch (op)
                {
                    case "+":
                        result = calculator.Add(num1, num2);
                        break;
                    case "-":
                        result = calculator.Substract(num1, num2);
                        break;
                    case "*":
                        result = calculator.Multiply(num1, num2);
                        break;
                    case "/":
                        result = calculator.Divide(num1, num2);
                        break;
                    default:
                        throw new Exception($"Invalid operation: {op}");
                }
                var calcResult = new CalcResult { Result = result };
                return View(calcResult);
            } 
            catch (Exception ex)
            {
                return Content($"{ex.Message}");
            }
        }


    }
}
