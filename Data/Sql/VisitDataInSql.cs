using Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data.Sql
{
   public class VisitDataInSql : IVisitData
    {
        private readonly BeautyShopDbContext beautyShopDbContext;

        public VisitDataInSql(BeautyShopDbContext beautyShopDbContext)
        {
            this.beautyShopDbContext = beautyShopDbContext;
        }

        public int Commit()
        {
            return beautyShopDbContext.SaveChanges();
        }

        public Visit Create(Visit visit)
        {
             beautyShopDbContext.Visits.Add(visit);
            return visit;
        }

        public Visit GetVisitById(int visitId)
        {
            return beautyShopDbContext.Visits.SingleOrDefault(v => v.Id == visitId);
        }

        public Visit GetVisitFullObjById(int id)
        {
            return beautyShopDbContext.Visits
                .Include(v => v.Customer)
                .ThenInclude(c => c.Membership)
                .Include(v => v.ShopItems)
                .SingleOrDefault(v => v.Id == id);

        }

        public IEnumerable<Visit> GetVisits(string searchTerm = null)
        {
            return beautyShopDbContext.Visits
               .Include(v => v.Customer)
               .ThenInclude(c => c.Membership)
               .Include(v => v.ShopItems)
               .Where(v => string.IsNullOrEmpty(searchTerm) ||
               v.Customer.FirstName.ToLower().StartsWith(searchTerm.ToLower())
               || v.Customer.LastName.ToLower().StartsWith(searchTerm.ToLower())).OrderBy(v => v.Customer.FirstName);
        }
    }
}
