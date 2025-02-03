using System.Text.Json;

namespace HNG_TASK1.Service
{
    public class NumberService
    {
        private static readonly HttpClient _httpClient = new HttpClient();
        public bool IsPrime(int number)
        {
            if (number < 2)
                return false;
            for (int i = 2; i <= Math.Sqrt(number); i++)
            {
                if (number % i == 0)
                    return false;
            }
            return true;
        }

        public bool IsPerfect(int number)
        {
            if (number < 2)
                return false;
            int sum = Enumerable.Range(1, number - 1).Where(i => number % i == 0).Sum();
            return sum == number;
        }

        public bool IsArmstrong(int number)
        {
            string digits = number.ToString();
            int length = digits.Length;
            int sum = digits.Sum(d => (int)Math.Pow(int.Parse(d.ToString()), length));
            return sum == number;
        }

        public int DigitSum(int number)
        {
            return number.ToString().Sum(c => int.Parse(c.ToString()));
        }


        public async Task<string> GetFunFact(int number)
        {
            if (IsArmstrong(number))
            {
                string explanation = string.Join(" + ", number.ToString().Select(d => $"{d}^{number.ToString().Length}"));
                return $"{number} is an Armstrong number because {explanation} = {number}";
            }
            string fact = await GetFunFactFromApi(number);

            return fact;
        }

        private async Task<string> GetFunFactFromApi(int number)
        {
            try
            {
                // Requesting fun fact from Numbers API (with math property)
                string url = $"http://numbersapi.com/{number}/math?json=true";
                HttpResponseMessage response = await _httpClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var factJson = await response.Content.ReadAsStringAsync();

                    // Parse the JSON response safely using JsonDocument
                    using (JsonDocument doc = JsonDocument.Parse(factJson))
                    {
                        // Check if the "text" property exists and return its value
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

    }
}
