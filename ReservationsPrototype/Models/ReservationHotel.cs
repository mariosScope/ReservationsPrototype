using System;
using System.Collections.Generic;

namespace ReservationsPrototype.Models
{
    public partial class ReservationHotel
    {
        public int Id { get; set; }
        public int ReservationId { get; set; }
        public int HotelId { get; set; }
        public DateTime? CheckInDate { get; set; }
        public TimeSpan? CheckInTime { get; set; }
        public DateTime? CheckOutDate { get; set; }

        public virtual Hotel Hotel { get; set; } = null!;
        public virtual Reservation Reservation { get; set; } = null!;
    }
}
