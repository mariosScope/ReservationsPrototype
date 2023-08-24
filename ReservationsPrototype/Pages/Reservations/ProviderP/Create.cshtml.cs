using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ReservationsPrototype.Data;
using ReservationsPrototype.Models;

namespace ReservationsPrototype.Pages.Reservations.ProviderP
{
    public class CreateModel : PageModel
    {
        private readonly ReservationsPrototype.Data.ProvidersContext _context;

        public CreateModel(ReservationsPrototype.Data.ProvidersContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Provider Providers { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Provider == null || Providers == null)
            {
                return Page();
            }

            _context.Provider.Add(Providers);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
