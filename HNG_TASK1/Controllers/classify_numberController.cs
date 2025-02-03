using HNG_TASK1.Model;
using HNG_TASK1.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HNG_TASK1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class classify_number : ControllerBase
    {
        private readonly NumberService _numberService;
        public classify_number()
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

            if (_numberService.IsArmstrong(parsedNumber))
                response.properties.Add("armstrong");
            if (parsedNumber % 2 != 0)
                response.properties.Add("odd");

            return Ok(response);
        }
    }
}
