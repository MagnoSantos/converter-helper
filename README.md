# Repositório Patterns Helper

## Features
- Conversão de duas entidades através das abstrações IOneWayConverter e/ou ITwoWayConverter
- Implementação do padrão de projetos Builder para criação de uma entidade

## Exemplo - Converter
- Definição das possibilidades de conversão: 

```cs
public interface IOneWayConverter<in TType, out TOtherType>
{
    TOtherType Convert(TType data);
}

public interface ITwoWayConverter<TType, TOtherType>
{
    TOtherType Convert(TType data);

    TType Convert(TOtherType data);
}
```

- Caso necessário realizar a conversão crie uma classe concreta que implemente essas interfaces, de acordo com sua necessidade. Exemplo: 
```cs
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
```

- Com isso, as classes de conversões ficarão separadas, facilitando o desenvolvimento de testes de unidade: 
```cs
 public class CustomerConverterTests
{
    private readonly IFixture _fixture;

    public CustomerConverterTests()
    {
        _fixture = new Fixture();
    }

    [Fact]
    public void MustConvertCustomer_Sucess()
    {
        //Arrange
        var customerDto = _fixture.Create<CustomerDto>();
        var converter = Instantiate();

        //Act
        var result = converter.Convert(customerDto);

        //Assert
        result.Should().NotBeNull();
        result.Name.Should().BeEquivalentTo(customerDto.Name);
        result.Cpf.Should().BeEquivalentTo(customerDto.Cpf);
        result.Email.Should().BeEquivalentTo(customerDto.Email);
        result.LastName.Should().BeEquivalentTo(customerDto.LastName);
    }

    private CustomerConverter Instantiate()
    {
        return new CustomerConverter();
    }
}
```

## Exemplo - Builder
- Definição abstração do padrão builder: 
```cs
public interface ICustomerBuilder
{
    ICustomerBuilder AddName(string name);

    ICustomerBuilder AddLastName(string lastName);

    ICustomerBuilder AddCpf(string cpf);

    ICustomerBuilder AddEmail(string email);

    CustomerDto Build();
}
```

- Definição da classe que implementa a abstração de builder:
```cs
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
```
- Para utilizar, será necessário chamar os métodos que fazem a construção de cada propriedade da entidade:

```cs
return builder
        .AddLastName(customerDto.Name)
        .AddCpf(customerDto.Cpf)
        .AddEmail(customerDto.Email)
        .AddName(customerDto.Name)
        .Build();
```
## License

MIT
