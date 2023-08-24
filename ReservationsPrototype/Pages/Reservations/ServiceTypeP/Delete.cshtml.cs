using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ReservationsPrototype.Data;
using ReservationsPrototype.Models;

namespace ReservationsPrototype.Pages.Reservations.ServiceTypeP
{
    public class DeleteModel : PageModel
    {
        private readonly ReservationsPrototype.Data.ReservationsContext _context;

        public DeleteModel(ReservationsPrototype.Data.ReservationsContext context)
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

            var servicetype = await _context.ServiceType.FirstOrDefaultAsync(m => m.ServiceTypeId == id);

            if (servicetype == null)
            {
                return NotFound();
            }
            else 
            {
                ServiceType = servicetype;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.ServiceType == null)
            {
                return NotFound();
            }
            var servicetype = await _context.ServiceType.FindAsync(id);

            if (servicetype != null)
            {
                ServiceType = servicetype;
                _context.ServiceType.Remove(ServiceType);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
