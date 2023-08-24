using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ReservationsPrototype.Models;

namespace ReservationsPrototype.Data
{
    public class ReservationsContext : DbContext
    {
        public ReservationsContext (DbContextOptions<ReservationsContext> options)
            : base(options)
        {
        }

        public DbSet<ReservationsPrototype.Models.Customer> Customer { get; set; } 

        public DbSet<ReservationsPrototype.Models.Provider>? Provider { get; set; }

        public DbSet<ReservationsPrototype.Models.Transport>? Transport { get; set; }

        public DbSet<ReservationsPrototype.Models.Tour>? Tour { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Reservation>(entity =>
            {
                entity.ToTable("Reservation");

                entity.Property(e => e.ReservationId).HasColumnName("reservation_id");

                entity.Property(e => e.CustomerId).HasColumnName("customer_id");

                entity.Property(e => e.EndDate)
                    .HasColumnType("datetime")
                    .HasColumnName("endDate");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasColumnName("isActive")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.StartDate)
                    .HasColumnType("datetime")
                    .HasColumnName("startDAte");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Reservations)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Customer_Reservation");
            });
            modelBuilder.Entity<Tour>(entity =>
            {
                entity.HasIndex(e => e.provider_id, "IX_tours_provider")
                   .IsUnique();

                entity.Property(e => e.tour_id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("tour_id");

                entity.Property(e => e.IsActive)
                    .HasColumnName("isActive")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.provider_id).HasColumnName("provider_id");

                entity.Property(e => e.TourAddress)
                    .HasMaxLength(10)
                    .HasColumnName("tourAddress")
                    .IsFixedLength();

                entity.Property(e => e.TourContact)
                    .HasMaxLength(10)
                    .HasColumnName("tourContact")
                    .IsFixedLength();

                entity.HasOne(d => d.Provider)
                    .WithMany(p => p.ToursProvided)
                    .HasForeignKey(d => d.provider_id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tours_Providers");
            });
            modelBuilder.Entity<ServiceType>(entity =>
            {
                entity.ToTable("ServiceType");

                entity.Property(e => e.ServiceTypeId).HasColumnName("serviceType_id");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasColumnName("isActive")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.ServiceName)
                    .HasMaxLength(10)
                    .HasColumnName("serviceName")
                    .IsFixedLength();
            });
            modelBuilder.Entity<Transport>(entity =>
            {
                entity.ToTable("Transport");

                entity.HasIndex(e => e.TransportId, "IX_Transport")
                    .IsUnique();

                entity.Property(e => e.TransportId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("transport_id");

                entity.Property(e => e.Availabilty)
                    .HasColumnType("datetime")
                    .HasColumnName("availabilty");

                entity.Property(e => e.Brand)
                    .HasMaxLength(10)
                    .HasColumnName("brand")
                    .IsFixedLength();

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasColumnName("isActive")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Model)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.TransportTypeId).HasColumnName("transportType_id");

                entity.Property(e => e.Year)
                    .HasColumnType("date")
                    .HasColumnName("year");

                entity.HasOne(d => d.TransportType)
                    .WithMany(p => p.Transports)
                    .HasForeignKey(d => d.TransportTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Transport_TransportType");
            });
            modelBuilder.Entity<TransportType>(entity =>
            {
                entity.Property(e => e.TransportTypeId).ValueGeneratedOnAdd().HasColumnName("transportType_id");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasColumnName("isActive")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.TransportTypeName)
                    .HasMaxLength(10)
                    .HasColumnName("transportType")
                    .IsFixedLength();
            });
           // OnModelCreatingPartial(modelBuilder);
        }

        public DbSet<ReservationsPrototype.Models.TransportType>? TransportType { get; set; }

        public DbSet<ReservationsPrototype.Models.ServiceType>? ServiceType { get; set; }

        public DbSet<ReservationsPrototype.Models.Reservation>? Reservation { get; set; }

        //parcial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
