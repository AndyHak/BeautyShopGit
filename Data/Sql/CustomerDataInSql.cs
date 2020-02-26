using Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data.Sql
{
    public class CustomerDataInSql : ICustomerData
    {
        private readonly BeautyShopDbContext beautyShopDbContext;

        public CustomerDataInSql(BeautyShopDbContext beautyShopDbContext)
        {
            this.beautyShopDbContext = beautyShopDbContext;
        }

        public int Commit()
        {
            return beautyShopDbContext.SaveChanges();
        }

        public Customer Create(Customer customer)
        {
            beautyShopDbContext.Customers.Add(customer);
            return customer;
        }

        public Customer GetCustomerById(int customerId)
        {
            return beautyShopDbContext.Customers
                .Include(c => c.Membership)
                .SingleOrDefault(c=>c.Id == customerId);
        }

        public IEnumerable<Customer> GetCustomers(string searchTerm = null)
        {
            return beautyShopDbContext.Customers
                .Include(c => c.Membership)
                .Where(c => string.IsNullOrEmpty(searchTerm)
                || c.FirstName.ToLower().StartsWith(searchTerm)
                || c.LastName.ToLower().StartsWith(searchTerm)).OrderBy(c => c.FirstName);
        }

        public Customer Update(Customer customer)
        {
            beautyShopDbContext.Entry(customer).State = EntityState.Modified;
            return customer;
        }
    }
}
