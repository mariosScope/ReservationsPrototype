using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ReservationsPrototype.Data;
using ReservationsPrototype.Models;

namespace ReservationsPrototype.Pages.Reservations.HotelP
{
    public class IndexModel : PageModel
    {
        private readonly ReservationsPrototype.Data.HotelContext _context;

        public IndexModel(ReservationsPrototype.Data.HotelContext context)
        {
            _context = context;
        }

        public IList<Hotel> Hotel { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Hotel != null)
            {
                Hotel = await _context.Hotel.ToListAsync();
            }
        }
    }
}
