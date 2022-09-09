using System.Linq;
using System.Threading;
using Feature.Customer;
using MediatR;
using Moq;
using Tests.Fixtures;
using Xunit;

namespace Tests.Mocks
{
    [Collection(nameof(CustomerCollection))]
    public class CustomerServiceTests
    {
        private CustomerTestFixture _customerTestFixtures;

        public CustomerServiceTests(
                CustomerTestFixture customerTestFixture)
        {
            _customerTestFixtures = customerTestFixture;
        }

        [Fact(DisplayName = "Add Customer must be valid")]
        public void CustomerService_Add_MustBeValid()
        {
            // Arrange
            var customer = _customerTestFixtures
                .GenerateValidCustomer().FirstOrDefault();

            var mockCustomerRepository = new Mock<ICustomerRepository>();
            var mockMediator = new Mock<IMediator>();
            var customerService = new CustomerService(
                    mockCustomerRepository.Object, 
                    mockMediator.Object);

            // Act
            customerService.Add(customer);

            // Assert
            Assert.True(customer.IsValid());

            // Verificando se o repositorio foi chamado uma vez
            mockCustomerRepository.Verify(r => r.Add(customer), Times.Once);
            /* mockMediator.Verify(m => */ 
            /* 				m.Publish( */
            /* 						It.IsAny<INotification>(), CancellationToken.None), */
            /* 				Times.Once); */
        }

        [Fact(DisplayName = "Add Customer must be invalid")]
        public void CustomerService_Add_MustBeInValid()
        {
            // Arrange
            var customer = _customerTestFixtures
                .GenerateInvalidCustomer();

            var mockCustomerRepository = new Mock<ICustomerRepository>();
            var mockMediator = new Mock<IMediator>();
            var customerService = new CustomerService(
                    mockCustomerRepository.Object, 
                    mockMediator.Object);

            // Act
            customerService.Add(customer);

            // Assert
            Assert.False(customer.IsValid());

            // Verificando se o repositorio foi chamado uma vez
            mockCustomerRepository.Verify(r => r.Add(customer), Times.Never);
            mockMediator.Verify(m => 
                    m.Publish(
                        It.IsAny<INotification>(), CancellationToken.None),
                    Times.Never);
        }

        [Fact(DisplayName = "Get Customer valid")]
        public void CustomerService()
        {
            var mockCustomerRepository = new Mock<ICustomerRepository>();
            var mockMediator = new Mock<IMediator>();

            // Quando chamar algo retorna isso
            mockCustomerRepository.Setup(m => m.GetAll())
                .Returns(_customerTestFixtures.GenerateValidCustomer());

            var customerService = new CustomerService(
                    mockCustomerRepository.Object, 
                    mockMediator.Object);

            var customers = customerService.GetAllActive();

            Assert.True(customers.Any());
            Assert.False(customers.Any(c => !c.Active));
        }
    }
}
