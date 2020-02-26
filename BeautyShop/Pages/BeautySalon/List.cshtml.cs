using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer;
using Core;
using Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BeautyShop.Pages
{
    public class ListModel : PageModel
    {
        private readonly IVisitData visitData;
        private readonly VIsitBl visitBl;
        public IEnumerable<Visit> Visits { get; set; }
        [TempData]
        public string Message { get; set; }
        [BindProperty(SupportsGet =true)]
        public string SearchTerm { get; set; }

        public ListModel(IVisitData visitData,VIsitBl visitBl)
        {
            this.visitData = visitData;
            this.visitBl = visitBl;
        }
        public double GetTotalExpenses(Visit visit)
        {
            return visitBl.TotalExpences(visit);
        }

        public void OnGet()
        {
            Visits = visitData.GetVisits(SearchTerm);
        }
    }
}