using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data.InMemory
{
    class MembershipDataInMemory : IMembershipData
    {
        private List<Membership> memberships;
        public MembershipDataInMemory()
        {
            memberships = new List<Membership>
            {
                new Membership(),
                new Membership(),
                new Membership(),
                new Membership(),

            };
        }

        public Membership GetMembershipById(int? membershipId)
        {
            return memberships.SingleOrDefault(m => m.Id == membershipId);
        }

        public IEnumerable<Membership> GetMemberships()
        {
            return memberships;
        }
    }
}
