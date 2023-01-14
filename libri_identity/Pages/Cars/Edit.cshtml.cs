﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using libri_identity.Data;
using libri_identity.Models;

namespace libri_identity.Pages.Cars
{
    public class EditModel : PageModel
    {
        private readonly libri_identity.Data.CarDbContext _context;

        [BindProperty]
        public Car Car { get; set; }

        public EditModel(libri_identity.Data.CarDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> OnGetAsync(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Car = await _context.Car.FirstOrDefaultAsync(m => m.Id == id);

            if (Car == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            Car.Name_Customer = User.Identity.Name;

            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Car).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CarExists(Car.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool CarExists(long id)
        {
            return _context.Car.Any(e => e.Id == id);
        }
    }
}
