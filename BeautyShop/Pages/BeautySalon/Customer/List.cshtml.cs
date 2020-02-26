using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BeautyShop.Pages.BeautySalon
{
    public class ListModel : PageModel
    {
        private readonly ICustomerData customerData;

        public ListModel(ICustomerData customerData)
        {
            this.customerData = customerData;
        }
        [BindProperty(SupportsGet =true)]
        public string SearchTerm { get; set; }
        [TempData]
        public string Message { get; set; }
        public IEnumerable<Core.Customer> Customers { get; set; }


        public void OnGet()
        {
            Customers = customerData.GetCustomers(SearchTerm);
        }
    }
}