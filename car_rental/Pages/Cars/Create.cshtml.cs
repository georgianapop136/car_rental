using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using car_rental.Data;
using car_rental.Models;
using Microsoft.AspNetCore.Authorization;

namespace car_rental.Pages.Cars
{
    [Authorize]
    public class CreateModel : PageModel
    {
        private readonly car_rental.Data.CarDbContext _context;

        [BindProperty]
        public Car Car { get; set; }

        public CreateModel(car_rental.Data.CarDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            Car.Name_Customer = User.Identity.Name;
            Car.State = 0;

            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Car.Add(Car);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
