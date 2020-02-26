using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data.Sql
{
   public class MembershipDataInSql : IMembershipData
    {
        private readonly BeautyShopDbContext beautyShopDbContext;

        public MembershipDataInSql(BeautyShopDbContext beautyShopDbContext)
        {
            this.beautyShopDbContext = beautyShopDbContext;
        }

        public Membership GetMembershipById(int? membershipId)
        {
            return beautyShopDbContext.Memberships.SingleOrDefault(m => m.Id == membershipId);
        }

        public IEnumerable<Membership> GetMemberships()
        {
            return beautyShopDbContext.Memberships.ToList();
        }
    }
}
