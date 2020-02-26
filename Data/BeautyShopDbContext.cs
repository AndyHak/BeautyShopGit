using Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data
{
    public class BeautyShopDbContext : DbContext
    {
        public BeautyShopDbContext(DbContextOptions<BeautyShopDbContext> options) : base(options)
        {
        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Membership>  Memberships { get; set; }
        public DbSet<Visit> Visits { get; set; }

    }
}
