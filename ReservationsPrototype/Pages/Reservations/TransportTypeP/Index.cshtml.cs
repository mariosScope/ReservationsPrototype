using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ReservationsPrototype.Data;
using ReservationsPrototype.Models;

namespace ReservationsPrototype.Pages.Reservations.TransportTypeP
{
    public class IndexModel : PageModel
    {
        private readonly ReservationsPrototype.Data.ReservationsContext _context;

        public IndexModel(ReservationsPrototype.Data.ReservationsContext context)
        {
            _context = context;
        }

        public IList<TransportType> TransportType { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.TransportType != null)
            {
                TransportType = await _context.TransportType.ToListAsync();
            }
        }
    }
}
