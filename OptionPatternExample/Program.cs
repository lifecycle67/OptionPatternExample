﻿using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using System.Collections.Specialized;
using System.Configuration;

namespace OptionPatternExample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ///ConfigurationBuilder를 통한 구성 공급자
            //ConfigurationBuilder configurationBuilder = new ConfigurationBuilder();
            //configurationBuilder.SetBasePath(Directory.GetCurrentDirectory());
            //configurationBuilder.AddJsonFile("appsettings.json", true, true);
            //var configurationRoot = configurationBuilder.Build();
            //var customConfigurationOptions = configurationRoot.GetSection(nameof(CustomConfigurationOptions)).Get<CustomConfigurationOptions>();


            HostApplicationBuilder builder = new HostApplicationBuilder();
            ///builder.Configuration.Sources.Clear()를 통해 기본값으로 추가된 구성 공급자를 제거합니다
            ///기본 구성 공급자 목록은 https://tinyurl.com/apu8ux35 페이지에서 remark 항목을 참조합니다
            builder.Configuration.Sources.Clear();
            builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            //appsettings.json의 구성 요소 중 CustomConfigurationOptions 요소를 가져옵니다
            var options = builder.Configuration.GetSection(nameof(CustomConfigurationOptions))
                                               .Get<CustomConfigurationOptions>();

            //CustomConfigurationOptions 요소를 종속성 주입 컨테이너에 등록합니다
            builder.Services.Configure<CustomConfigurationOptions>(
                builder.Configuration.GetSection(nameof(CustomConfigurationOptions)));

            builder.Services.Configure<OptionFeatures>(OptionFeatures.Base,
                                                 builder.Configuration.GetSection("OptionFeatures:Base"));
            builder.Services.Configure<OptionFeatures>(OptionFeatures.Derive,
                                                 builder.Configuration.GetSection("OptionFeatures:Derive"));

            //builder.Services.AddOptionsWithValidateOnStart<ValidateOption>()
            //                //.AddOptions<ValidateOption>()
            //                .Bind(builder.Configuration.GetSection(ValidateOption.SectionName))
            //                .ValidateDataAnnotations()
            //                .Validate(config =>
            //                {
            //                    if (config.Qty >= 200)
            //                        return config.DueDate < DateTime.Parse("2025-12-31 23:59:59");
            //                    return true;
            //                }, "Qty가 200이상 일 경우 DueDate는 2025-12-31 23:59:59 이전이어야 합니다.");

            builder.Services.Configure<ValidateOption>(
                builder.Configuration.GetSection(ValidateOption.SectionName));


            //종속성 주입 컨테이너에 TestService 클래스를 등록합니다
            builder.Services.AddTransient<TestService>();
            builder.Services.AddScoped<ScopedService>();
            builder.Services.AddTransient<MonitorService>();
            builder.Services.AddTransient<NamedOptionsService>();
            builder.Services.AddTransient<ValidationService>();
            builder.Services.AddSingleton<IValidateOptions<ValidateOption>, CustomeValidatation>();

            ///TestService 클래스에 CustomConfigurationOptions이 주입됨을 확인하기 위해,
            ///TestService의 종속성을 해결합니다.
            var serviceProvider = builder.Services.BuildServiceProvider();
            //serviceProvider.GetRequiredService<TestService>();

            //IOptionsSnapshotService(serviceProvider);
            //IOptionsMonitorService(serviceProvider);

            ///IOptionsMonitor 인터페이스에서 OnChange 함수를 호출 했을 때 Dispose 호출 유무에 따른 메모리 누수를 확인합니다.
            //RequestManyIOptionsMonitorService(serviceProvider);
            //GC.Collect();

            ///Named Options 
            UseNamedOptionsService(serviceProvider);

            ///options validation
            //UseValidateOptionService(serviceProvider);

            ///IOption 의 경우 구성 값이 변경되었는지 확인합니다
            //serviceProvider.GetRequiredService<TestService>();

            //var namedoptionService = serviceProvider.GetRequiredService<NamedOptionsService>();
            var host = builder.Build();
            host.Run();
        }

        private static void IOptionsSnapshotService(ServiceProvider serviceProvider)
        {
            ///scope 범위를 지정해서 IOptionsSnapshot 인스턴스를 다시 생성합니다
            using (var scope = serviceProvider.CreateScope())
            {
                scope.ServiceProvider.GetRequiredService<ScopedService>();
            }

            Console.Write("appsettings.json에서 CustomConfigurationOptions의 값을 변경 후 enter를 입력합니다 : ");
            Console.ReadLine();

            ///scope 범위를 지정해서 IOptionsSnapshot 인스턴스를 다시 생성합니다
            using (var scope = serviceProvider.CreateScope())
            {
                scope.ServiceProvider.GetRequiredService<ScopedService>();
            }

            ///IOption 의 경우 구성 값이 변경되었는지 확인합니다
            serviceProvider.GetRequiredService<TestService>();
        }


        private static void IOptionsMonitorService(ServiceProvider serviceProvider)
        {
            var monitorService = serviceProvider.GetRequiredService<MonitorService>();
            monitorService.DisplayOption();

            Console.Write("appsettings.json에서 CustomConfigurationOptions의 값을 변경 후 enter를 입력합니다 : ");
            Console.ReadLine();

            monitorService.DisplayOption();
        }

        private static void RequestManyIOptionsMonitorService(ServiceProvider serviceProvider)
        {
            for (int i = 0; i < 200; i++)
            {
                var monitorService = serviceProvider.GetRequiredService<MonitorService>().ReturnSelf();
                ///호출 유무에 따른 메모리 누수를 확인합니다.
                //monitorService.Dispose();
            }
        }

        private static void UseNamedOptionsService(ServiceProvider serviceProvider)
        {
            serviceProvider.GetRequiredService<NamedOptionsService>();
        }

        private static void UseValidateOptionService(ServiceProvider serviceProvider)
        {
            serviceProvider.GetRequiredService<ValidationService>();
        }
    }
}
