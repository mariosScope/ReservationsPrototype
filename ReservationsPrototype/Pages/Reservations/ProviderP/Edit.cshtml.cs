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

namespace ReservationsPrototype.Pages.Reservations.ProviderP
{
    public class EditModel : PageModel
    {
        private readonly ReservationsPrototype.Data.ProvidersContext _context;

        public EditModel(ReservationsPrototype.Data.ProvidersContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Provider Providers { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Provider == null)
            {
                return NotFound();
            }

            var providers =  await _context.Provider.FirstOrDefaultAsync(m => m.provider_id == id);
            if (providers == null)
            {
                return NotFound();
            }
            Providers = providers;
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

            _context.Attach(Providers).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProvidersExists(Providers.provider_id))
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

        private bool ProvidersExists(int id)
        {
          return (_context.Provider?.Any(e => e.provider_id == id)).GetValueOrDefault();
        }
    }
}
