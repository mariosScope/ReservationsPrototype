using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ReservationsPrototype.Models
{
    public partial class TransportType
    {
        public TransportType()
        {
            Transports = new HashSet<Transport>();
        }

        [Key] public int TransportTypeId { get; set; }
        public string? TransportTypeName { get; set; }
        public bool? IsActive { get; set; }

        public virtual ICollection<Transport> Transports { get; set; }
    }
}
