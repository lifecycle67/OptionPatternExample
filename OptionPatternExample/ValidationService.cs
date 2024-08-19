using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptionPatternExample
{
    public class ValidationService
    {
        private readonly IOptions<ValidateOption> _options;

        public ValidationService(IOptions<ValidateOption> options)
        {
            _options = options;

            try
            {
                ValidateOption validateSection = _options.Value;
                Console.WriteLine($"valid OptionsValidationSection.Title:{validateSection.Title}");
                Console.WriteLine($"valid OptionsValidationSection.Email:{validateSection.Email}");
                Console.WriteLine($"valid OptionsValidationSection.Qty:{validateSection.Qty}");
                Console.WriteLine($"valid OptionsValidationSection.DueDate:{validateSection.DueDate}");
            }
            catch (OptionsValidationException ex)
            {
                foreach (var failure in ex.Failures)
                {
                    Console.WriteLine($"Validation error : {failure}");
                }
            }
        }
    }
}
