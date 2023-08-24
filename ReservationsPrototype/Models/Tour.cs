using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ReservationsPrototype.Models
{
    public partial class Tour
    {
        public Tour()
        {
            ReservationTours = new HashSet<ReservationTour>();
        }

        [Key] public int tour_id { get; set; }
        public int provider_id { get; set; }
        public string? TourAddress { get; set; }
        public string? TourContact { get; set; }
        public bool? IsActive { get; set; }

        public virtual Provider? Provider { get; set; } = null!;
        public virtual ICollection<ReservationTour> ReservationTours { get; set; }
    }
}
