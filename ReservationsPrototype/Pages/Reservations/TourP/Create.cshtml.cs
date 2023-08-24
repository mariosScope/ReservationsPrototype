using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using ReservationsPrototype.Data;
using ReservationsPrototype.Models;

namespace ReservationsPrototype.Pages.Reservations.TourP
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
            Console.WriteLine(_context.Provider);
        ViewData["provider_id"] = new SelectList(_context.Provider, "provider_id", "provider_id");
            return Page();
        }

        [BindProperty]
        public Tour Tour { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            Console.WriteLine(_context.Tour);
          if (!ModelState.IsValid || _context.Tour == null || Tour == null)
            {
                Console.WriteLine(Tour.provider_id);
                Console.WriteLine("'GRITAS!!!!!!!!!!'");
                return Page();
            }

            _context.Tour.Add(Tour);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
