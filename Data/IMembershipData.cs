using Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data
{
    public interface IMembershipData
    {
        Membership GetMembershipById(int? membershipId);
        IEnumerable<Membership> GetMemberships();
    }
}
