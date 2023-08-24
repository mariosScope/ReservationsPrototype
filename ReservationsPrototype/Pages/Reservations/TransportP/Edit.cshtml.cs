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

namespace ReservationsPrototype.Pages.Reservations.TransportP
{
    public class EditModel : PageModel
    {
        private readonly ReservationsPrototype.Data.ReservationsContext _context;

        public EditModel(ReservationsPrototype.Data.ReservationsContext context)
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

            var transport =  await _context.Transport.FirstOrDefaultAsync(m => m.TransportId == id);
            if (transport == null)
            {
                return NotFound();
            }
            Transport = transport;
           ViewData["TransportTypeId"] = new SelectList(_context.Set<TransportType>(), "TransportTypeId", "TransportTypeId");
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

            _context.Attach(Transport).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TransportExists(Transport.TransportId))
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

        private bool TransportExists(int id)
        {
          return (_context.Transport?.Any(e => e.TransportId == id)).GetValueOrDefault();
        }
    }
}
