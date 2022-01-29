using Feature.Core;

namespace Feature.Customer
{
		public interface ICustomerRepository : IRepository<Customer>
		{
				Customer GetByEmail(string email);
		}
}
