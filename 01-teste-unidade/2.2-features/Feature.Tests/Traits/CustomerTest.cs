using System.Linq;
using Tests.Fixtures;
using Xunit;

namespace Tests.Traits
{
    [Collection(nameof(CustomerCollection))]
    public class CustomerTestValid
    {
        private CustomerTestFixture _customerTestFixture;

        public CustomerTestValid(CustomerTestFixture customerTestFixture)
        {
            _customerTestFixture = customerTestFixture;
        }

        [Fact]
        public void Customer_NewCustomer_MustBeValid()
        {
            var customer = _customerTestFixture.GenerateValidCustomer()
                .FirstOrDefault();

            // Act
            var res = customer.IsValid();

            // Assert
            Assert.True(res);
            Assert.Equal(0, customer.ValidationResult.Errors.Count);
        }

    }

    [Collection(nameof(CustomerCollection))]
    public class CustomerTestInvalid
    {
        private CustomerTestFixture _customerTestFixture;

        public CustomerTestInvalid(CustomerTestFixture customerTestFixture)
        {
            _customerTestFixture = customerTestFixture;
        }

        [Fact]
        public void Customer_NewCustomer_MustBeInvalid()
        {
            // Arrange
            var customer = _customerTestFixture.GenerateInvalidCustomer();

            // Act
            var res = customer.IsValid();

            // Assert
            Assert.False(res);
            Assert.NotEqual(0, customer.ValidationResult.Errors.Count);
        }
    }
}
