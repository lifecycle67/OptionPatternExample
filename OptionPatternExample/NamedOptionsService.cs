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
        public readonly OptionFeatures _baseFeature;
        public readonly OptionFeatures _deriveFeature;

        public NamedOptionsService(IOptionsSnapshot<OptionFeatures> namedOptionFeatures)
        {
            _baseFeature = namedOptionFeatures.Get(OptionFeatures.Base);
            _deriveFeature = namedOptionFeatures.Get(OptionFeatures.Derive);

            Console.WriteLine($"Base OptionFeatures.Url:{_baseFeature.Url}");
            Console.WriteLine($"Base OptionFeatures.Enabled:{_baseFeature.Enabled}");
            Console.WriteLine($"Derive OptionFeatures.Url:{_deriveFeature.Url}");
            Console.WriteLine($"Derive OptionFeatures.Enabled:{_deriveFeature.Enabled}");
        }
    }
}
