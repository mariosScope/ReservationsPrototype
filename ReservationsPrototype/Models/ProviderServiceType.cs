using System;
using System.Collections.Generic;

namespace ReservationsPrototype.Models
{
    public partial class ProviderServiceType
    {
        public int Id { get; set; }
        public int ProviderId { get; set; }
        public int ServiceTypeId { get; set; }

        public virtual Provider Provider { get; set; } = null!;
        public virtual ServiceType ServiceType { get; set; } = null!;
    }
}
