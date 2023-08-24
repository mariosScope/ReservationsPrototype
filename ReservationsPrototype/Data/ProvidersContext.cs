using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ReservationsPrototype.Models;

namespace ReservationsPrototype.Data
{
    public class ProvidersContext : DbContext
    {
        public ProvidersContext (DbContextOptions<ProvidersContext> options)
            : base(options)
        {
        }

        public DbSet<ReservationsPrototype.Models.Provider> Provider { get; set; } = default!;
    }
}
