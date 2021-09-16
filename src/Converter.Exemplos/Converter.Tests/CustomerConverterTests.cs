using AutoFixture;
using Converter.Domain.Entitties;
using Converter.InterfaceType.Converter;
using FluentAssertions;
using Xunit;

namespace Converter.Tests
{
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
}