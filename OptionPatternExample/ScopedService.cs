using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptionPatternExample
{
    public class ScopedService
    {
        private readonly CustomConfigurationOptions _options;

        public ScopedService(IOptionsSnapshot<CustomConfigurationOptions> options)
        {
            _options = options.Value;

            Console.WriteLine($"IOptionsSnapshot CustomConfigurationOptions.Deadline:{_options.Deadline}");
            Console.WriteLine($"IOptionsSnapshot CustomConfigurationOptions.Enabled:{_options.Enabled}");
            Console.WriteLine($"IOptionsSnapshot CustomConfigurationOptions.Retry:{_options.Retry}");
            Console.WriteLine($"IOptionsSnapshot CustomConfigurationOptions.Level:{_options.Level}");
        }
    }
}
