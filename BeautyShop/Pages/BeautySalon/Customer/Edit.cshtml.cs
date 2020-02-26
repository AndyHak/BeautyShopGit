using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core;
using Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BeautyShop.Pages.BeautySalon.Customer
{
    public class EditModel : PageModel
    {
        private readonly ICustomerData customerData;
        private readonly IMembershipData membershipData;

        public EditModel(ICustomerData customerData,IMembershipData membershipData)
        {
            this.customerData = customerData;
            this.membershipData = membershipData;
        }
        [BindProperty]
        public Core.Customer Customer { get; set; }

       public IEnumerable<SelectListItem> Memberships { get; set; } 

        public IActionResult OnGet(int? id)
        {
            if (id.HasValue)
            {
                Customer = customerData.GetCustomerById(id.Value);
                if (Customer == null)
                {
                    RedirectToPage("./NotFound");
                }
            }
            else
            {
                Customer = new Core.Customer();
            }
            var membershis = membershipData.GetMemberships().ToList().Select(m => new { Id = m.Id, Display = m.MembershipType });
            Memberships = new SelectList(membershis, "Id", "Display");
            return Page();
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                if (Customer.Id == 0)
                {
                    Customer = customerData.Create(Customer);
                    TempData["Message"] = "The Object is Created!";
                }
                else
                {
                    Customer = customerData.Update(Customer);
                    TempData["Message"] = "The Object is Updated!";
                }
                customerData.Commit();
                return RedirectToPage("./List");
            }
            var membershis = membershipData.GetMemberships().ToList().Select(m => new { Id = m.Id, Display = m.MembershipType });
            Memberships = new SelectList(membershis, "Id", "Display");
            return Page();  

        }
    }
}