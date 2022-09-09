using System;
using System.Collections.Generic;

namespace Feature.Customer
{
    public interface ICustomerService : IDisposable
    {
        IEnumerable<Customer> GetAllActive();
        void Add(Customer customer);
        void Update(Customer customer);
        void Remove(Customer customer);
    }
}
