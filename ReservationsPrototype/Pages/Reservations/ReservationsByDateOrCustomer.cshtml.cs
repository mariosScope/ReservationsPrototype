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

namespace ReservationsPrototype.Pages.Reservations
{
    public class ReservationsByDateOrCustomerModel : PageModel
    {
        private readonly ReservationsPrototype.Data.ReservationsContext _context;

        public ReservationsByDateOrCustomerModel(ReservationsPrototype.Data.ReservationsContext context)
        {
            _context = context;
        }

        public IList<Reservation> Reservations { get;set; } = new List<Reservation>();
        
        [BindProperty]
        public Reservation ReservationBinded { get; set; } = default!;
        
        [BindProperty]
        public DateTime? BeginDate { get; set; }

        [BindProperty]
        public DateTime? EndDate { get; set; }

        [BindProperty]
        public int? CustomerId { get; set; }

        public List<Reservation> FilteredReservations { get; set; }

        public async Task OnGetAsync()
        {
            ViewData["CustomerId"] = new SelectList(_context.Customer, "customer_id", "FirstName");

            //if (_context.Reservation != null)
            //{
            //    Reservations = await _context.Reservation
            //    .Include(r => r.Customer).ToListAsync();
            //}
        }

        public async Task<IActionResult> OnPostAsync()
        {
            IQueryable<Reservation> query = _context.Reservation;

            // Apply filters based on user input
            if (BeginDate.HasValue)
            {
                query = query.Where(r => r.StartDate >= BeginDate.Value);
            }

            if (EndDate.HasValue)
            {
                query = query.Where(r => r.EndDate <= EndDate.Value);
            }

            if (CustomerId.HasValue)
            {
                Console.WriteLine("Valor para customer.");
                query = query.Where(r => r.CustomerId == CustomerId.Value);
            }

            // Execute the query and store the filtered reservations
            Reservations = query.ToList();

            return Page();
        }
    }
}
