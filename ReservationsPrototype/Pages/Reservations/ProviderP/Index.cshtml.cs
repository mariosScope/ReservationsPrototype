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
    public class IndexModel : PageModel
    {
        private readonly ReservationsPrototype.Data.ProvidersContext _context;

        public IndexModel(ReservationsPrototype.Data.ProvidersContext context)
        {
            _context = context;
        }

        public IList<Provider> Providers { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Provider != null)
            {
                Providers = await _context.Provider.ToListAsync();
            }
        }
    }
}
