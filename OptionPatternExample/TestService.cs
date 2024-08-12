using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace OptionPatternExample
{
    public class TestService
    {
        private readonly CustomConfigurationOptions _options;
        public TestService(IOptions<CustomConfigurationOptions> options)
        {
            _options = options.Value;

            Console.WriteLine($"CustomConfigurationOptions.Deadline:{_options.Deadline}");
            Console.WriteLine($"CustomConfigurationOptions.Enabled:{_options.Enabled}");
        }
    }
}
