using HNG_TASK1.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HNG_TASK1.Controllers
{
    [Route("api/classify-number")]
    [ApiController]
    public class ClassifyNumberController : ControllerBase
    {
        private static readonly HttpClient _httpClient = new HttpClient();

        // Helper methods for number classification
        // Helper methods for number classification
        private bool IsPrime(int number)
        {
            // Handle negative numbers by taking their absolute value
            number = Math.Abs(number);
            if (number < 2)
                return false;
            for (int i = 2; i <= Math.Sqrt(number); i++)
            {
                if (number % i == 0)
                    return false;
            }
            return true;
        }

        private bool IsPerfect(int number)
        {
            // Handle negative numbers by taking their absolute value
            number = Math.Abs(number);
            if (number < 2)
                return false;
            int sum = Enumerable.Range(1, number - 1).Where(i => number % i == 0).Sum();
            return sum == number;
        }

        private bool IsArmstrong(int number)
        {
            // Handle negative numbers by taking their absolute value
            number = Math.Abs(number);
            string digits = number.ToString();
            int length = digits.Length;
            int sum = digits.Sum(d => (int)Math.Pow(int.Parse(d.ToString()), length));
            return sum == number;
        }

        private int DigitSum(int number)
        {
            // Handle negative numbers by taking their absolute value
            number = Math.Abs(number);
            return number.ToString().Sum(c => int.Parse(c.ToString()));
        }

        private async Task<string> GetFunFact(int number)
        {
            try
            {
                string url = $"http://numbersapi.com/{number}/math?json=true";
                HttpResponseMessage response = await _httpClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var factJson = await response.Content.ReadAsStringAsync();
                    using (var doc = System.Text.Json.JsonDocument.Parse(factJson))
                    {
                        if (doc.RootElement.TryGetProperty("text", out var factElement))
                        {
                            return factElement.GetString();
                        }
                        else
                        {
                            return "No fun fact available.";
                        }
                    }
                }
                else
                {
                    return "No fun fact available.";
                }
            }
            catch (Exception ex)
            {
                return $"An error occurred while fetching the fact: {ex.Message}";
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetNumberProperties([FromQuery] string number)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { error = true });
            }

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
                is_prime = IsPrime(parsedNumber),
                is_perfect = IsPerfect(parsedNumber),
                digit_sum= DigitSum(parsedNumber),
                fun_fact = await GetFunFact(parsedNumber)
            };

            // Determine properties based on the new requirements
            bool isArmstrong = IsArmstrong(parsedNumber);
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
