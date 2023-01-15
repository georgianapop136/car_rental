using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using car_rental.Data;
using car_rental.Models;
using Microsoft.AspNetCore.Authorization;

namespace car_rental.Pages.BookingCRUD
{
    [Authorize]
    public class DeleteModel : PageModel
    {
        private readonly car_rental.Data.CarDbContext _context;

        public DeleteModel(car_rental.Data.CarDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Booking Booking { get; set; }

        public Car Car { get; set; }

        public async Task<IActionResult> OnGetAsync(long? id_search)
        {
            if (id_search == null)
            {
                return NotFound();
            }

            Booking = await _context.Booking.FirstOrDefaultAsync(m => m.Id_Booking == id_search);

            if (Booking == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(long? id_search)
        {
            if (id_search == null)
            {
                return NotFound();
            }

            Booking = await _context.Booking.FindAsync(id_search);

            if (Booking != null)
            {
                Car = await _context.Car.FirstOrDefaultAsync(m => m.Id == Booking.Id_Car);

                if (Car == null)
                {
                    return NotFound();
                }
                Car.State = 0;

                _context.Booking.Remove(Booking);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
