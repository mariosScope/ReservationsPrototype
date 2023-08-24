using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ReservationsPrototype.Models
{
    public partial class ServiceType
    {
        public ServiceType()
        {
            ProviderServiceTypes = new HashSet<ProviderServiceType>();
        }

        [Key] public int ServiceTypeId { get; set; }
        public string? ServiceName { get; set; }
        public bool? IsActive { get; set; }

        public virtual ICollection<ProviderServiceType> ProviderServiceTypes { get; set; }
    }
}
