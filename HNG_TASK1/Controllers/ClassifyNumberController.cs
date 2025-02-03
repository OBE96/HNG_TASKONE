using HNG_TASK1.Model;
using HNG_TASK1.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HNG_TASK1.Controllers
{
    [Route("api/classify-number")]
    [ApiController]
    public class ClassifyNumberController : ControllerBase
    {
        private readonly NumberService _numberService;
        public ClassifyNumberController()
        {
            _numberService = new NumberService();
        }

        [HttpGet]
        public IActionResult GetNumberProperties([FromQuery] string number)
        {
            if (!int.TryParse(number, out int parsedNumber))
            {
                return BadRequest(new
                {
                    number = number,
                    error = true
                });
            }

            var response = new NumberPropertiesResponse
            {
                number = parsedNumber,
                is_Prime = _numberService.IsPrime(parsedNumber),
                is_Perfect = _numberService.IsPerfect(parsedNumber),
                digit_sum= _numberService.DigitSum(parsedNumber),
                fun_fact = _numberService.GetFunFact(parsedNumber)
            };

            // Determine properties based on the new requirements
            bool isArmstrong = _numberService.IsArmstrong(parsedNumber);
            bool isOdd = parsedNumber % 2 != 0;

            if (isArmstrong && isOdd)
            {
                response.properties.Add("armstrong");
                response.properties.Add("odd");
            }
            else if (isArmstrong && !isOdd)
            {
                response.properties.Add("armstrong");
                response.properties.Add("even");
            }
            else if (!isArmstrong && isOdd)
            {
                response.properties.Add("odd");
            }
            else
            {
                response.properties.Add("even");
            }

            return Ok(response);
        }
    }
}
