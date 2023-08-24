using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ReservationsPrototype.Models
{
    public partial class Reservation
    {
        public Reservation()
        {
            ReservationHotels = new HashSet<ReservationHotel>();
            ReservationTours = new HashSet<ReservationTour>();
            ReservationTransports = new HashSet<ReservationTransport>();
        }

        [Key] public int ReservationId { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int CustomerId { get; set; }
        public bool? IsActive { get; set; }

        public virtual Customer? Customer { get; set; } = null!;
        public virtual ICollection<ReservationHotel> ReservationHotels { get; set; }
        public virtual ICollection<ReservationTour> ReservationTours { get; set; }
        public virtual ICollection<ReservationTransport> ReservationTransports { get; set; }
    }
}
