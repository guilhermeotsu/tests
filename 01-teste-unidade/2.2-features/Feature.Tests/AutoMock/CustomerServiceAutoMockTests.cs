using System.Linq;
using Feature.Customer;
using Moq.AutoMock;
using Tests.Fixtures;
using Xunit;

namespace Feature.Tests.AutoMock
{
    public class CustomerServiceAutoMockTests
    {
        private CustomerTestFixture _customerFixture;

        public CustomerServiceAutoMockTests(
                CustomerTestFixture customerTestFixture)
        {
            _customerFixture = customerTestFixture;
        }

        [Fact]
        public void ClienteService_Add_MustBeValid()
        {
            // Arrange
            var clientes = _customerFixture.GenerateValidCustomer();
            var mocker = new AutoMocker();
            var clienteService = mocker.CreateInstance<CustomerService>();

            // Act
            clienteService.Add(clientes.First());

            // Assert
        }
    }
}
