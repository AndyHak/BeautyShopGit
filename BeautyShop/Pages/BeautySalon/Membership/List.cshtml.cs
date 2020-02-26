using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core;
using Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BeautyShop
{
    public class ListModel : PageModel
    {
        private readonly IMembershipData membershipData;

        public ListModel(IMembershipData membershipData)
        {
            this.membershipData = membershipData;
        }

        public IEnumerable<Membership> Memberships { get; set; }
        public void OnGet()
        {
            Memberships = membershipData.GetMemberships();
        }
    }
}