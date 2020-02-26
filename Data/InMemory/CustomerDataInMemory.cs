using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data.InMemory
{
    class CustomerDataInMemory : ICustomerData
    {
        private List<Customer> customers;

        public CustomerDataInMemory()
        {
            customers = new List<Customer>();
        }

        public int Commit()
        {
            return 0;
        }

        public Customer Create(Customer customer)
        {
            customer.Id = customers.Any() ? customers.Max(c => c.Id) + 1 : 1;
            customers.Add(customer);
            return customer;
        }

        public Customer GetCustomerById(int customerId)
        {
            return customers.Single(c => c.Id == customerId);
        }

        public IEnumerable<Customer> GetCustomers(string searchTerm = null)
        {
            return customers
                .Where(c => string.IsNullOrEmpty(searchTerm) || c.FirstName.ToLower().StartsWith(searchTerm.ToLower())
                || c.LastName.ToLower().StartsWith(searchTerm.ToLower())).OrderBy(c => c.FirstName);
        }

        public Customer Update(Customer customer)
        {
            var custTemp = customers.SingleOrDefault(c => c.Id == customer.Id);
            if (custTemp != null)
            {
                custTemp.FirstName = customer.FirstName;
                custTemp.LastName = customer.LastName;
                custTemp.Membership = customer.Membership;
                custTemp.MembershipId = customer.MembershipId;
            }
            return custTemp;
        }
    }
}
