using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ReservationsPrototype.Data;
using ReservationsPrototype.Models;

namespace ReservationsPrototype.Pages.Reservations.TransportP
{
    public class CreateModel : PageModel
    {
        private readonly ReservationsPrototype.Data.ReservationsContext _context;

        public CreateModel(ReservationsPrototype.Data.ReservationsContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["TransportTypeId"] = new SelectList(_context.Set<TransportType>(), "TransportTypeId", "TransportTypeId");
            return Page();
        }

        [BindProperty]
        public Transport Transport { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Transport == null || Transport == null)
            {
                return Page();
            }

            _context.Transport.Add(Transport);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
