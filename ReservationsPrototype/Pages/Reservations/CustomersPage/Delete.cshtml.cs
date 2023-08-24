using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ReservationsPrototype.Data;
using ReservationsPrototype.Models;

namespace ReservationsPrototype.Pages.Reservations.CustomersPage
{
    public class DeleteModel : PageModel
    {
        private readonly ReservationsPrototype.Data.ReservationsContext _context;

        public DeleteModel(ReservationsPrototype.Data.ReservationsContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Customer Customers { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Customer == null)
            {
                return NotFound();
            }

            var customers = await _context.Customer.FirstOrDefaultAsync(m => m.customer_id == id);

            if (customers == null)
            {
                return NotFound();
            }
            else 
            {
                Customers = customers;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Customer == null)
            {
                return NotFound();
            }
            var customers = await _context.Customer.FindAsync(id);

            if (customers != null)
            {
                Customers = customers;
                _context.Customer.Remove(Customers);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
