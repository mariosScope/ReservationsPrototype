using System;
using System.Collections.Generic;

namespace ReservationsPrototype.Models
{
    public partial class ReservationTour
    {
        public int Id { get; set; }
        public int ReservationId { get; set; }
        public int TourId { get; set; }
        public DateTime? BookedDate { get; set; }

        public virtual Reservation Reservation { get; set; } = null!;
        public virtual Tour Tour { get; set; } = null!;
    }
}
