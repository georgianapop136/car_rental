using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using libri_identity.Data;
using libri_identity.Models;

namespace libri_identity.Pages.Cars
{
    public class IndexModel : PageModel
    {
        private readonly libri_identity.Data.CarDbContext _context;

        [BindProperty]
        public string Brand_filter { set; get; }
        [BindProperty]
        public string Model_filter { set; get; }
        [BindProperty]
        public string Location_filter { set; get; }
        [BindProperty]
        public string Customer_filter { set; get; }

        public IndexModel(libri_identity.Data.CarDbContext context)
        {
            _context = context;
        }

        public IList<Car> Car { get;set; }

        public async Task OnGetAsync()
        {
            Car = await _context.Car.ToListAsync();
        }

        public async Task<IActionResult> OnPostAsync(string Brand_filter, string Model_filter, string Location_filter, string Customer_filter)
        {
            var Car_search = await _context.Car.ToListAsync();

            if (Brand_filter == null && Model_filter == null && Location_filter == null && Customer_filter == null)
                Car_search = await _context.Car.ToListAsync(); ;
            if (Brand_filter != null)
                Car_search = Car_search.Where(m => m.Brand.ToLower() == Brand_filter.ToLower()).ToList();
            if (Model_filter != null)
                Car_search = Car_search.Where(m => m.Model.ToLower() == Model_filter.ToLower()).ToList();
            if (Location_filter != null)
                Car_search = Car_search.Where(m => m.Location.ToLower() == Location_filter.ToLower()).ToList();
            if (Customer_filter != null)
                Car_search = Car_search.Where(m => m.Name_Customer.ToLower() == Customer_filter.ToLower()).ToList();

            Car = Car_search;

            return Page();
        }
    }
}
