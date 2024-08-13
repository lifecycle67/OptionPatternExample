using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptionPatternExample
{
    public class Features
    {
        public const string Personalize = nameof(Personalize);
        public const string WeatherStation = nameof(WeatherStation);

        public bool Enabled { get; set; }
        public string ApiKey { get; set; }
    }
}
