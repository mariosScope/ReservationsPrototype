using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ReservationsPrototype.Data;
using ReservationsPrototype.Models;

namespace ReservationsPrototype.Pages.Reservations.TourP
{
    public class DeleteModel : PageModel
    {
        private readonly ReservationsPrototype.Data.ReservationsContext _context;

        public DeleteModel(ReservationsPrototype.Data.ReservationsContext context)
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

            var tours = await _context.Tour.FirstOrDefaultAsync(m => m.tour_id == id);

            if (tours == null)
            {
                return NotFound();
            }
            else 
            {
                Tours = tours;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Tour == null)
            {
                return NotFound();
            }
            var tours = await _context.Tour.FindAsync(id);

            if (tours != null)
            {
                Tours = tours;
                _context.Tour.Remove(Tours);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
