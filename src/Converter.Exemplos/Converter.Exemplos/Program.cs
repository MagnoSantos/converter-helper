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

            //Conversão pelas abstracoes IOneWayConverter ou ITwoWayConverter
            using var serviceScope = host.Services.CreateScope();
            var provider = serviceScope.ServiceProvider;

            var customerDto = new CustomerDto
            {
                Name = "Teste", 
                Cpf = "12345678900",
                Email = "teste@neon.com.br",
                LastName = "LastTest"
            };
            var converter = provider.GetRequiredService<IOneWayConverter<CustomerDto, CustomerDataBase>>();
            var result = converter.Convert(customerDto);

            return host.RunAsync();
        }

        static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((_, services) =>
                    services.AddSingleton<IOneWayConverter<CustomerDto, CustomerDataBase>, CustomerConverter>());
    }
}
