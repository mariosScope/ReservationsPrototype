using System;
using System.Collections.Generic;

namespace ReservationsPrototype.Models
{
    public partial class ReservationTransport
    {
        public int Id { get; set; }
        public int ReservationId { get; set; }
        public int TransportId { get; set; }
        public DateTime? BookedDate { get; set; }

        public virtual Reservation Reservation { get; set; } = null!;
        public virtual Transport Transport { get; set; } = null!;
    }
}
