using Converter.Domain.Entitties;
using Converter.InterfaceType;
using Converter.InterfaceType.Converter;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Pattern.Builder;
using System.Threading.Tasks;

namespace Converter.Exemplos
{
    internal class Program
    {
        private static Task Main(string[] args)
        {
            using IHost host = CreateHostBuilder(args).Build();

            var customerDto = new CustomerDto
            {
                Name = "Teste",
                Cpf = "12345678900",
                Email = "teste@neon.com.br",
                LastName = "LastTest"
            };

            //Conversão (customerDto em customerDataBase) pelas abstracoes IOneWayConverter ou ITwoWayConverter
            var converter = Converter(host, customerDto);

            //Builder (customerDto) pela abstração ICustomerBuilder
            var builder = Build(host, customerDto);

            return host.RunAsync();
        }

        private static CustomerDataBase Converter(IHost host, CustomerDto customerDto)
        {
            var serviceScope = host.Services.CreateScope();
            var provider = serviceScope.ServiceProvider;
            
            var converter = provider.GetRequiredService<IOneWayConverter<CustomerDto, CustomerDataBase>>();
            return converter.Convert(customerDto);
        }

        private static CustomerDto Build(IHost host, CustomerDto customerDto)
        {
            var serviceScope = host.Services.CreateScope();
            var provider = serviceScope.ServiceProvider;

            var builder = provider.GetRequiredService<ICustomerBuilder>();
            
            return builder
                .AddLastName(customerDto.Name)
                .AddCpf(customerDto.Cpf)
                .AddEmail(customerDto.Email)
                .AddName(customerDto.Name)
                .Build();
        }

        private static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((_, services) =>
                    services.AddSingleton<IOneWayConverter<CustomerDto, CustomerDataBase>, CustomerConverter>()
                            .AddSingleton<ICustomerBuilder, CustomerBuilder>());
    }
}