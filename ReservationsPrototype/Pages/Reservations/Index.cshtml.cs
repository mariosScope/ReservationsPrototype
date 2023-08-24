using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ReservationsPrototype.Data;
using ReservationsPrototype.Models;

namespace ReservationsPrototype.Pages.Reservations
{
    public class IndexModel : PageModel
    {
        private readonly ReservationsPrototype.Data.ReservationsContext _context;

        public IndexModel(ReservationsPrototype.Data.ReservationsContext context)
        {
            _context = context;
        }

        public IList<Reservation> Reservation { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Reservation != null)
            {
                Reservation = await _context.Reservation
                .Include(r => r.Customer).ToListAsync(); 
            }
            Console.WriteLine(Reservation[0].Customer.FirstName);
        }
    }
}
