namespace HNG_TASK1.Service
{
    public class NumberService
    {
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

        public string GetFunFact(int number)
        {
            if (IsArmstrong(number))
            {
                string explanation = string.Join(" + ", number.ToString().Select(d => $"{d}^{number.ToString().Length}"));
                return $"{number} is an Armstrong number because {explanation} = {number}";
            }
            return $"{number} is a fascinating number, but no specific fun fact is available.";
        }
    
    }
}
