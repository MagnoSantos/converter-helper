using Converter.Domain.Entitties;

namespace Pattern.Builder
{
    public class CustomerBuilder : ICustomerBuilder
    {
        private readonly CustomerDto _customerDto;

        public CustomerBuilder()
        {
            _customerDto = new CustomerDto();
        }

        public ICustomerBuilder AddCpf(string cpf)
        {
            _customerDto.Cpf = cpf;
            return this;
        }

        public ICustomerBuilder AddEmail(string email)
        {
            _customerDto.Email = email;
            return this;
        }

        public ICustomerBuilder AddLastName(string lastName)
        {
            _customerDto.LastName = lastName;
            return this;
        }

        public ICustomerBuilder AddName(string name)
        {
            _customerDto.Name = name;
            return this;
        }

        public CustomerDto Build()
        {
            return _customerDto;
        }
    }
}