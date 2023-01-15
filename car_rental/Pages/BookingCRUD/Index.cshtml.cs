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
    public class IndexModel : PageModel
    {
        private readonly car_rental.Data.CarDbContext _context;

        public IndexModel(car_rental.Data.CarDbContext context)
        {
            _context = context;
        }

        public IList<Booking> Booking { get;set; }

        public async Task OnGetAsync()
        {
            Booking = await _context.Booking.ToListAsync();
        }
    }
}
