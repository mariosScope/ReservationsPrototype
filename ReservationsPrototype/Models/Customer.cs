using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ReservationsPrototype.Models
{
    public partial class Customer
    {
        public Customer()
        {
            Reservations = new HashSet<Reservation>();
        }
        
        [Key]
        public int customer_id { get; set; }
        public string FirstName { get; set; } = null!;
        public string? LastName { get; set; }
        public string? Identification { get; set; }
        public string? BirthDate { get; set; }
        public string? Nationality { get; set; }
        public string? CustomerPhoneNumber { get; set; }
        public string? CustomerEmail { get; set; }
        public bool? IsActive { get; set; }

        public virtual ICollection<Reservation> Reservations { get; set; }
    }
}
