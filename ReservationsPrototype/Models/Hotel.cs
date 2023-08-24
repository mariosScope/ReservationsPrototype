using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ReservationsPrototype.Models
{
    public partial class Hotel
    {
        public Hotel()
        {
            ReservationHotels = new HashSet<ReservationHotel>();
        }
        [Key]
        public int hotel_id { get; set; }
        public string? HotelName { get; set; }
        public string? HotelAddress { get; set; }
        public string? HotelContactNumber { get; set; }
        public bool? IsActive { get; set; }

        public virtual ICollection<ReservationHotel> ReservationHotels { get; set; }
    }
}
