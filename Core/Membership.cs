using System;
using System.Collections.Generic;
using System.Text;

namespace Core
{
    public class Membership
    {
        public Membership()
        {
            DiscountProducts = 15 / 100;
        }
        public int Id { get; set; }
        public string MembershipType { get; set; }

        public double DiscountProducts { get; set; }
        public double DiscountServices { get; set; }

    }
}
