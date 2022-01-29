using System.Collections.Generic;
using System.Linq;
using MediatR;

namespace Feature.Customer
{
		public class CustomerService : ICustomerService
		{
				private readonly ICustomerRepository _cutomerRepository;
				private readonly IMediator _mediator;

				public CustomerService(
								ICustomerRepository customerRepository,
								IMediator mediator)
				{
						_mediator = mediator;
						_cutomerRepository = customerRepository;
				}

				public IEnumerable<Customer> GetAllActive()
						=> _cutomerRepository.GetAll().Where(q => q.Active);

				public void Add(Customer customer)
				{
						if(!customer.IsValid())
								return;

						_cutomerRepository.Add(customer);
						_mediator.Publish(new CustomerEmailNotification(
												"admin@me.com", customer.Email));
				}

				public void Update(Customer customer)
				{
						if(!customer.IsValid())
								return;

						_cutomerRepository.Update(customer);
						_mediator.Publish(new CustomerEmailNotification(
												"admin@me.com", customer.Email));
				}

				public void Inactivate(Customer customer)
				{
						if(!customer.IsValid())
								return;

						customer.Inactive();
						_cutomerRepository.Update(customer);
						_mediator.Publish(new CustomerEmailNotification(
												"admin@me.com", customer.Email));
				}

				public void Remove(Customer customer)
				{
						_cutomerRepository.Remove(customer);
						_mediator.Publish(new CustomerEmailNotification(
												"admin@me.com", customer.Email));
				}

        public void Dispose()
        {
            throw new System.NotImplementedException();
        }
    }
}
