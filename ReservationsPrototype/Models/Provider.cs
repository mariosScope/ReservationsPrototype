using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ReservationsPrototype.Models
{
    public partial class Provider
    {
        public Provider()
        {
            ProviderServiceTypes = new HashSet<ProviderServiceType>();
        }

        [Key]
        public int provider_id { get; set; }
        public string? ProviderName { get; set; }
        public string? ProviderContactNumber { get; set; }
        public string? ProviderEmail { get; set; }
        public string? ProviderPersonToContact { get; set; }
        public string? ProviderAddress { get; set; }
        public bool? IsActive { get; set; }

        public virtual ICollection<Tour>? ToursProvided { get; set; }
        public virtual ICollection<ProviderServiceType> ProviderServiceTypes { get; set; }
    }
}
