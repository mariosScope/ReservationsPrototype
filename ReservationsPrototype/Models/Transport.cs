using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ReservationsPrototype.Models
{
    public partial class Transport
    {
        public Transport()
        {
            ReservationTransports = new HashSet<ReservationTransport>();
        }

        [Key] public int TransportId { get; set; }
        public string? Brand { get; set; }
        public int? Capacity { get; set; }
        public string? Model { get; set; }
        public DateTime? Year { get; set; }
        public DateTime? Availabilty { get; set; }
        public bool? IsActive { get; set; }
        public int TransportTypeId { get; set; }

        public virtual TransportType? TransportType { get; set; } = null!;
        public virtual ICollection<ReservationTransport> ReservationTransports { get; set; }
    }
}
