using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptionPatternExample
{
    public class NamedOptionsService
    {
        public readonly Features _personalizeFeature;
        public readonly Features _weatherStationFeature;

        public NamedOptionsService(IOptionsSnapshot<Features> namedOptionsAccessor)
        {
            _personalizeFeature = namedOptionsAccessor.Get(Features.Personalize);
            _weatherStationFeature = namedOptionsAccessor.Get(Features.WeatherStation);

            Console.WriteLine($"Personalize CustomConfigurationOptions.ApiKey:{_personalizeFeature.ApiKey}");
            Console.WriteLine($"Personalize CustomConfigurationOptions.Enabled:{_personalizeFeature.Enabled}");
            Console.WriteLine($"WeatherStation CustomConfigurationOptions.ApiKey:{_weatherStationFeature.ApiKey}");
            Console.WriteLine($"WeatherStation CustomConfigurationOptions.Enabled:{_weatherStationFeature.Enabled}");
        }
    }
}
