using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace OptionPatternExample
{
    public class MonitorService
    {
        private readonly IOptionsMonitor<CustomConfigurationOptions> _options;
        IDisposable? _disposableOnChanges;

        public MonitorService(IOptionsMonitor<CustomConfigurationOptions> options)
        {
            _options = options;

            ///OnChange 함수는 IDisposable 형식을 반환합니다.
            ///메모리 누수를 방지하기 위해서 서비스의 수명이 끝날 때 IDisposable.Dispose를 호출해야 합니다.
            //_disposableOnChanges = options.OnChange((opt, str) => { });
        }

        public void DisplayOption()
        {
            Console.WriteLine($"IOptionsMonitor CustomConfigurationOptions.Deadline:{_options.CurrentValue.Deadline}");
            Console.WriteLine($"IOptionsMonitor CustomConfigurationOptions.Enabled:{_options.CurrentValue.Enabled}");
            Console.WriteLine($"IOptionsMonitor CustomConfigurationOptions.Retry:{_options.CurrentValue.Retry}");
            Console.WriteLine($"IOptionsMonitor CustomConfigurationOptions.Level:{_options.CurrentValue.Level}");
        }

        public MonitorService ReturnSelf()
        {
            return this;
        }

        public void Dispose()
        {
            _disposableOnChanges?.Dispose();
        }
    }
}
