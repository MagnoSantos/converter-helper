using Converter.Domain.Entitties;

namespace Pattern.Builder
{
    public interface ICustomerBuilder
    {
        ICustomerBuilder AddName(string name);

        ICustomerBuilder AddLastName(string lastName);

        ICustomerBuilder AddCpf(string cpf);

        ICustomerBuilder AddEmail(string email);

        CustomerDto Build();
    }
}