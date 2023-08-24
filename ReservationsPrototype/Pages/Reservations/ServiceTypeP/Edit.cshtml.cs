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

namespace ReservationsPrototype.Pages.Reservations.ServiceTypeP
{
    public class EditModel : PageModel
    {
        private readonly ReservationsPrototype.Data.ReservationsContext _context;

        public EditModel(ReservationsPrototype.Data.ReservationsContext context)
        {
            _context = context;
        }

        [BindProperty]
        public ServiceType ServiceType { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.ServiceType == null)
            {
                return NotFound();
            }

            var servicetype =  await _context.ServiceType.FirstOrDefaultAsync(m => m.ServiceTypeId == id);
            if (servicetype == null)
            {
                return NotFound();
            }
            ServiceType = servicetype;
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

            _context.Attach(ServiceType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ServiceTypeExists(ServiceType.ServiceTypeId))
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

        private bool ServiceTypeExists(int id)
        {
          return (_context.ServiceType?.Any(e => e.ServiceTypeId == id)).GetValueOrDefault();
        }
    }
}
