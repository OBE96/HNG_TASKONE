namespace HNG_TASK1.Model
{
    public class NumberPropertiesResponse
    {
        public int number { get; set; }
        public bool is_Prime { get; set; }
        public bool is_Perfect { get; set; }
        public List<string> properties { get; set; } = new List<string>();
        public int digit_sum { get; set; }
        public string? fun_fact { get; set; }
    }
}
