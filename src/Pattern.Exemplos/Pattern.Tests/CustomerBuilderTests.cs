using AutoFixture;
using FluentAssertions;
using Pattern.Builder;
using Xunit;

namespace Converter.Tests
{
    public class CustomerBuilderTests
    {
        private IFixture _fixture;

        public CustomerBuilderTests()
        {
            _fixture = new Fixture();
        }

        [Fact]
        public void CustomerBuilderAddCpf_ShouldOperationSucessful()
        {
            var cpf = _fixture.Create<string>();
            var builder = Instantiate();

            var result = builder.AddCpf(cpf).Build();

            result.Should().NotBeNull();
            result.Cpf.Should().BeEquivalentTo(cpf);
        }

        [Fact]
        public void CustomerBuilderAddEmail_ShouldOperationSucessful()
        {
            var email = _fixture.Create<string>();
            var builder = Instantiate();

            var result = builder.AddEmail(email).Build();

            result.Should().NotBeNull();
            result.Email.Should().BeEquivalentTo(email);
        }

        [Fact]
        public void CustomerBuilderAddName_ShouldOperationSucessful()
        {
            var name = _fixture.Create<string>();
            var builder = Instantiate();

            var result = builder.AddName(name).Build();

            result.Should().NotBeNull();
            result.Name.Should().BeEquivalentTo(name);
        }

        [Fact]
        public void CustomerBuilderAddLastName_ShouldOperationSucessful()
        {
            var lastName = _fixture.Create<string>();
            var builder = Instantiate();

            var result = builder.AddLastName(lastName).Build();

            result.Should().NotBeNull();
            result.LastName.Should().BeEquivalentTo(lastName);
        }

        private CustomerBuilder Instantiate()
        {
            return new CustomerBuilder();
        }
    }
}