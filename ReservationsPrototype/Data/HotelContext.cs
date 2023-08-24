using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ReservationsPrototype.Models;

namespace ReservationsPrototype.Data
{
    public class HotelContext : DbContext
    {
        public HotelContext (DbContextOptions<HotelContext> options)
            : base(options)
        {
        }

        public DbSet<ReservationsPrototype.Models.Hotel> Hotel { get; set; } = default!;
    }
}
