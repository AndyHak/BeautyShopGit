using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer;
using Core;
using Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BeautyShop.Pages
{
    public class EditModel : PageModel
    {
        private readonly IVisitData visitData;
        private readonly ICustomerData customerData;
        private readonly VIsitBl visitBl;
       

        public EditModel(IVisitData visitData, ICustomerData customerData, VIsitBl visitBl)
        {
            this.visitData = visitData;
            this.visitBl = visitBl;
            this.customerData = customerData;
        }
        [BindProperty]
        public Visit Visit { get; set; }
        public string Message { get; set; }
        public IEnumerable<SelectListItem> Customers { get; set; }
        
        public IActionResult OnGet()
        {
            Visit = new Visit();
            var customers = customerData.GetCustomers().ToList().Select(c => new { Id = c.Id, Display = $"{c.FirstName} {c.LastName}" });
            Customers = new SelectList(customers, "Id", "Display");
            return Page();
        }
        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                var customer = customerData.GetCustomerById(Visit.CustomoerId.Value);
                Visit.Customer = customer;

                Visit = visitData.Create(Visit);
                TempData["Message"] = "The Visit is Created";
                visitData.Commit();
                return RedirectToPage("./List");
            }
            var customers = customerData.GetCustomers().ToList().Select(c => new { Id = c.Id, Display = $"{c.FirstName} {c.LastName}" });
            Customers = new SelectList(customers, "Id", "Display");
            return Page();

        }

        public IActionResult OnPostBuy(double? ServicePrice , double? ProductPrice)
        {
            if (ModelState.IsValid)
            {
                var customer = customerData.GetCustomerById(Visit.CustomoerId.Value);
                Visit.Customer = customer;

                if(ProductPrice.HasValue && ProductPrice.Value > 0)
                {
                    Visit.ShopItems.Add(visitBl.CreateProduct(ProductPrice.Value));
                }
                if(ServicePrice.HasValue && ServicePrice.Value > 0)
                {
                    Visit.ShopItems.Add(visitBl.CreateService(ServicePrice.Value));
                }
            }
            Message = Visit.CustomoerId == null ? "No customer selected." : $"Total expences: {visitBl.TotalExpences(Visit)}";
            var customers = customerData.GetCustomers().ToList().Select(p => new { Id = p.Id, Display = $"{p.FirstName} {p.LastName}" });
            Customers = new SelectList(customers, "Id", "Display");
            return Page();
        }
    }
}