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

namespace ReservationsPrototype.Pages.Reservations.TransportTypeP
{
    public class EditModel : PageModel
    {
        private readonly ReservationsPrototype.Data.ReservationsContext _context;

        public EditModel(ReservationsPrototype.Data.ReservationsContext context)
        {
            _context = context;
        }

        [BindProperty]
        public TransportType TransportType { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.TransportType == null)
            {
                return NotFound();
            }

            var transporttype =  await _context.TransportType.FirstOrDefaultAsync(m => m.TransportTypeId == id);
            if (transporttype == null)
            {
                return NotFound();
            }
            TransportType = transporttype;
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

            _context.Attach(TransportType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TransportTypeExists(TransportType.TransportTypeId))
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

        private bool TransportTypeExists(int id)
        {
          return (_context.TransportType?.Any(e => e.TransportTypeId == id)).GetValueOrDefault();
        }
    }
}
