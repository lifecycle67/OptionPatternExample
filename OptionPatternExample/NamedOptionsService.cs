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
        }
    }
}
