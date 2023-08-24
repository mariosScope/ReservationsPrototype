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
    public class DetailsModel : PageModel
    {
        private readonly ReservationsPrototype.Data.ReservationsContext _context;

        public DetailsModel(ReservationsPrototype.Data.ReservationsContext context)
        {
            _context = context;
        }

      public TransportType TransportType { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.TransportType == null)
            {
                return NotFound();
            }

            var transporttype = await _context.TransportType.FirstOrDefaultAsync(m => m.TransportTypeId == id);
            if (transporttype == null)
            {
                return NotFound();
            }
            else 
            {
                TransportType = transporttype;
            }
            return Page();
        }
    }
}
