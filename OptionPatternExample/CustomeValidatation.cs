using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptionPatternExample
{
    public class CustomeValidatation : IValidateOptions<ValidateOption>
    {
        private readonly IConfiguration _configuration;

        public CustomeValidatation(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public ValidateOptionsResult Validate(string? name, ValidateOption options)
        {
            StringBuilder? sb = null;

            ///Qty에 대한 검증 조건을 추가합니다. 
            ///ValidateDataAnnotations 메서드를 호출했다면
            ///ValidateOption 클래스에 DataAnnotation으로 설정한 조건과 중복 적용 됩니다.
            if (options.Qty < 0 || options.Qty > 50)
                (sb ??= new()).AppendLine($"The field {nameof(options.Qty)}({options.Qty}) must be between 0 and 50");

            if (sb == null)
                return ValidateOptionsResult.Success;

            return ValidateOptionsResult.Fail(sb.ToString());
        }
    }
}
