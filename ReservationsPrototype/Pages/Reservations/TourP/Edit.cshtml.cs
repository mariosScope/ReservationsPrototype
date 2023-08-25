using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ReservationsPrototype.Data;
using ReservationsPrototype.Models;

namespace ReservationsPrototype.Pages.Reservations.TourP
{
    public class EditModel : PageModel
    {
        private readonly ReservationsPrototype.Data.ReservationsContext _context;

        public EditModel(ReservationsPrototype.Data.ReservationsContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Tour Tours { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Tour == null)
            {
                return NotFound();
            }

            var tours =  await _context.Tour.FirstOrDefaultAsync(m => m.tour_id == id);
            if (tours == null)
            {
                return NotFound();
            }
            Tours = tours;
           ViewData["ProviderId"] = new SelectList(_context.Provider, "ProviderId", "ProviderName");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Tours).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ToursExists(Tours.tour_id))
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

        private bool ToursExists(int id)
        {
          return (_context.Tour?.Any(e => e.tour_id == id)).GetValueOrDefault();
        }
    }
}
