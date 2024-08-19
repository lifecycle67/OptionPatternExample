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
        public readonly OptionFeatures _personalizeFeature;
        public readonly OptionFeatures _weatherStationFeature;

        public NamedOptionsService(IOptionsSnapshot<OptionFeatures> namedOptionFeatures)
        {
            _personalizeFeature = namedOptionFeatures.Get(OptionFeatures.Base);
            _weatherStationFeature = namedOptionFeatures.Get(OptionFeatures.Derive);

            Console.WriteLine($"Personalize CustomConfigurationOptions.ApiKey:{_personalizeFeature.Url}");
            Console.WriteLine($"Personalize CustomConfigurationOptions.Enabled:{_personalizeFeature.Enabled}");
            Console.WriteLine($"WeatherStation CustomConfigurationOptions.ApiKey:{_weatherStationFeature.Url}");
            Console.WriteLine($"WeatherStation CustomConfigurationOptions.Enabled:{_weatherStationFeature.Enabled}");
        }
    }
}
