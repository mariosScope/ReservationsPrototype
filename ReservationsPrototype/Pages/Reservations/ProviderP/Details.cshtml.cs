using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ReservationsPrototype.Data;
using ReservationsPrototype.Models;

namespace ReservationsPrototype.Pages.Reservations.ProviderP
{
    public class DetailsModel : PageModel
    {
        private readonly ReservationsPrototype.Data.ProvidersContext _context;

        public DetailsModel(ReservationsPrototype.Data.ProvidersContext context)
        {
            _context = context;
        }

      public Provider Providers { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Provider == null)
            {
                return NotFound();
            }

            var providers = await _context.Provider.FirstOrDefaultAsync(m => m.provider_id == id);
            if (providers == null)
            {
                return NotFound();
            }
            else 
            {
                Providers = providers;
            }
            return Page();
        }
    }
}
