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
using Microsoft.EntityFrameworkCore;

namespace car_rental.Pages.BookingCRUD
{
    [Authorize]
    public class CreateModel : PageModel
    {
        private readonly car_rental.Data.CarDbContext _context;

        [BindProperty]
        public Booking Booking { set; get; }

        //[BindProperty]
        public Car Car { set; get; }

        public CreateModel(car_rental.Data.CarDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> OnGet(long? id_car)
        {
            if (id_car == null)
            {
                return NotFound();
            }

            Car = await _context.Car.FirstOrDefaultAsync(m => m.Id == id_car);

            if (Car == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(long? id_car)
        {
            if (id_car == null)
            {
                return NotFound();
            }

            Car = await _context.Car.FirstOrDefaultAsync(m => m.Id == id_car);

            if (Car == null)
            {
                return NotFound();
            }

            Booking.Start_Booking = DateTime.Now.ToString("dd/MM/yyyy");
            Booking.End_Booking = DateTime.Now.AddDays(30).ToString("dd/MM/yyyy");
            Booking.Brand = Car.Brand;
          
            Booking.Customer = User.Identity.Name;
            Booking.Id_Car = id_car.Value;
            Car.State = 1;

            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Booking.Add(Booking);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
