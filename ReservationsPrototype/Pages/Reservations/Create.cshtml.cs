using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ReservationsPrototype.Data;
using ReservationsPrototype.Models;

namespace ReservationsPrototype.Pages.Reservations
{
    public class CreateModel : PageModel
    {
        private readonly ReservationsPrototype.Data.ReservationsContext _context;
        private readonly ReservationsPrototype.Data.HotelContext _hotel_context;

        public CreateModel(ReservationsPrototype.Data.ReservationsContext context, ReservationsPrototype.Data.HotelContext hotel_context)
        {
            _context = context;
            _hotel_context = hotel_context;
        }

        public IActionResult OnGet()
        {
            ViewData["CustomerId"] = new SelectList(_context.Customer, "customer_id", "FirstName");
            ViewData["Hotel"] = new SelectList(_hotel_context.Hotel, "hotel_id", "HotelName");
            //ViewData["Tours"] = new SelectList(_context.Tour, "tour_id", "tour_id");

            ViewData["Tours"] = new SelectList(
                from tour in _context.Tour
                join provider in _context.Provider on tour.provider_id equals provider.provider_id
                select new
                {
                    TourId = tour.tour_id,
                    DisplayName = provider.ProviderName
                },
                "TourId",
                "DisplayName"
            );


            ViewData["Transports"] = new SelectList(_context.Transport, "TransportId", "Model");

            return Page();
        }

        [BindProperty]
        public Reservation Reservation { get; set; } = default!;
        [BindProperty]
        public int SelectedHotelId { get; set; }
        [BindProperty]
        public int SelectedTourId { get; set; }
        [BindProperty]
        public int SelectedTransportId { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Reservation == null || Reservation == null)
            {
                ViewData["Hotel"] = new SelectList(_hotel_context.Hotel, "hotel_id", "HotelName");
                ViewData["Tours"] = new SelectList(_context.Tour, "tour_id", "tour_id");
                ViewData["Transports"] = new SelectList(_context.Transport, "TransportId", "Model");
                return Page();
            }
            // Assign selected hotels, tours, and transports to the reservation

            Reservation.ReservationHotels.Add(new ReservationHotel { HotelId = SelectedHotelId });
            
            Reservation.ReservationTours.Add(new ReservationTour { TourId = SelectedTourId });
            
            Reservation.ReservationTransports.Add(new ReservationTransport { TransportId = SelectedTransportId });
            await _context.SaveChangesAsync();

            _context.Reservation.Add(Reservation);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
