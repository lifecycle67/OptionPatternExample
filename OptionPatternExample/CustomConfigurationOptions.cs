namespace OptionPatternExample
{
    public class CustomConfigurationOptions
    {
        public TimeSpan Deadline { get; set; }
        public bool Enabled { get; set; }
        public int Retry { get; set; }
        public string Level { get; set; }
    }
}