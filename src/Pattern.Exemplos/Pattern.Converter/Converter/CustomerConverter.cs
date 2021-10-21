using Converter.Domain.Entitties;
using System;

namespace Converter.InterfaceType.Converter
{
    public class CustomerConverter : IOneWayConverter<CustomerDto, CustomerDataBase>
    {
        public CustomerDataBase Convert(CustomerDto data)
        {
            return new CustomerDataBase
            {
                Identifier = Guid.NewGuid(),
                CreateAt = DateTime.UtcNow,
                Name = data.Name,
                Email = data.Email,
                Cpf = data.Cpf,
                LastName = data.LastName
            };
        }
    }

    public class CustomerConverterTwo : ITwoWayConverter<CustomerDto, CustomerDataBase>
    {
        //TODO: Testes seguindo a mesma estrutura do IOneWayConverter
        public CustomerDataBase Convert(CustomerDto data)
        {
            return new CustomerDataBase
            {
                Identifier = Guid.NewGuid(),
                CreateAt = DateTime.UtcNow,
                Name = data.Name,
                Email = data.Email,
                Cpf = data.Cpf,
                LastName = data.LastName
            };
        }

        //TODO: Testes seguindo a mesma estrutura do IOneWayConverter
        public CustomerDto Convert(CustomerDataBase data)
        {
            return new CustomerDto
            {
                Name = data.Name,
                Email = data.Email,
                Cpf = data.Cpf,
                LastName = data.LastName
            };
        }
    }
}