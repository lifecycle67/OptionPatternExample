using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptionPatternExample
{
    public class MonitorService(IOptionsMonitor<CustomConfigurationOptions> options, IOptionsMonitor<Features> features)
    {
        private readonly CustomConfigurationOptions _customConfigurationOptions;
        private readonly Features _features;

        public void DisplayOption()
        {
            var opt = options.CurrentValue;
            var ss = features.CurrentValue;

            Console.WriteLine($"IOptionsMonitor CustomConfigurationOptions.Deadline:{opt.Deadline}");
            Console.WriteLine($"IOptionsMonitor CustomConfigurationOptions.Enabled:{opt.Enabled}");
            Console.WriteLine($"IOptionsMonitor CustomConfigurationOptions.Retry:{opt.Retry}");
            Console.WriteLine($"IOptionsMonitor CustomConfigurationOptions.Level:{opt.Level}");
        }
    }
}
