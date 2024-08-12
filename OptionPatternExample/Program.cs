using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

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
            ///new HostApplicationBuilder()를 통해 기본값으로 추가된 구성 공급자를 제거합니다
            ///기본 구성 공급자 목록은 https://tinyurl.com/apu8ux35 페이지에서 remark 항목을 참조합니다
            builder.Configuration.Sources.Clear(); 
            builder.Configuration.AddJsonFile("appsettings.json");

            //appsettings.json의 구성 요소 중 CustomConfigurationOptions 요소를 가져옵니다
            var options = builder.Configuration.GetSection(nameof(CustomConfigurationOptions))
                                               .Get<CustomConfigurationOptions>();

            //CustomConfigurationOptions 요소를 종속성 주입 컨테이너에 등록합니다
            builder.Services.Configure<CustomConfigurationOptions>(
                builder.Configuration.GetSection(nameof(CustomConfigurationOptions)));

            //종속성 주입 컨테이너에 TestService 클래스를 등록합니다
            builder.Services.AddTransient<TestService>();

            ///TestService 클래스에 CustomConfigurationOptions이 주입됨을 확인하기 위해,
            ///TestService의 종속성을 해결합니다.
            var serviceProvider = builder.Services.BuildServiceProvider();
            var testService = serviceProvider.GetRequiredService<TestService>();

            Console.WriteLine("hello");
        }
    }
}
