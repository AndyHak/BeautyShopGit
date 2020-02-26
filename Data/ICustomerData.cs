using Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data
{
    public interface ICustomerData
    {
        Customer Create(Customer customer);
        Customer Update(Customer customer);
        Customer GetCustomerById(int customerId);
        IEnumerable<Customer> GetCustomers(string searchTerm=null);
        int Commit();
    }
}
