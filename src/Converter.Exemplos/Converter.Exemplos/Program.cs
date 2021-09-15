using Converter.InterfaceType;
using Converter.InterfaceType.Converter;
using Converter.InterfaceType.Entities;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Threading.Tasks;

namespace Converter.Exemplos
{
    class Program
    {
        static Task Main(string[] args)
        {
            using IHost host = CreateHostBuilder(args).Build();
            
            return host.RunAsync();
        }

        static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((_, services) =>
                    services.AddSingleton<IOneWayConverter<CustomerDto, CustomerDataBase>, CustomerConverter>());
    }
}
