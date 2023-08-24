using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ReservationsPrototype.Data;
using ReservationsPrototype.Models;

namespace ReservationsPrototype.Pages.Reservations.TransportP
{
    public class DeleteModel : PageModel
    {
        private readonly ReservationsPrototype.Data.ReservationsContext _context;

        public DeleteModel(ReservationsPrototype.Data.ReservationsContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Transport Transport { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Transport == null)
            {
                return NotFound();
            }

            var transport = await _context.Transport.FirstOrDefaultAsync(m => m.TransportId == id);

            if (transport == null)
            {
                return NotFound();
            }
            else 
            {
                Transport = transport;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Transport == null)
            {
                return NotFound();
            }
            var transport = await _context.Transport.FindAsync(id);

            if (transport != null)
            {
                Transport = transport;
                _context.Transport.Remove(Transport);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
