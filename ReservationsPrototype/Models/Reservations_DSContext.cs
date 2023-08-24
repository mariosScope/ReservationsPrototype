using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ReservationsPrototype.Models
{
    public partial class Reservations_DSContext : DbContext
    {
        public Reservations_DSContext()
        {
        }

        public Reservations_DSContext(DbContextOptions<Reservations_DSContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Customer> Customers { get; set; } = null!;
        public virtual DbSet<Hotel> Hotels { get; set; } = null!;
        public virtual DbSet<Provider> Providers { get; set; } = null!;
        public virtual DbSet<ProviderServiceType> ProviderServiceTypes { get; set; } = null!;
        public virtual DbSet<Reservation> Reservations { get; set; } = null!;
        public virtual DbSet<ReservationHotel> ReservationHotels { get; set; } = null!;
        public virtual DbSet<ReservationTour> ReservationTours { get; set; } = null!;
        public virtual DbSet<ReservationTransport> ReservationTransports { get; set; } = null!;
        public virtual DbSet<ServiceType> ServiceTypes { get; set; } = null!;
        public virtual DbSet<Tour> Tours { get; set; } = null!;
        public virtual DbSet<Transport> Transports { get; set; } = null!;
        public virtual DbSet<TransportType> TransportTypes { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.\\SQLExpress;Database=Reservations_DS;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>(entity =>
            {
                entity.Property(e => e.customer_id)
                    .ValueGeneratedNever()
                    .HasColumnName("customer_id");

                entity.Property(e => e.BirthDate)
                    .HasMaxLength(10)
                    .HasColumnName("birthDate")
                    .IsFixedLength();

                entity.Property(e => e.CustomerEmail)
                    .HasMaxLength(10)
                    .HasColumnName("customerEmail")
                    .IsFixedLength();

                entity.Property(e => e.CustomerPhoneNumber)
                    .HasMaxLength(10)
                    .HasColumnName("customerPhoneNumber")
                    .IsFixedLength();

                entity.Property(e => e.FirstName)
                    .HasMaxLength(10)
                    .HasColumnName("firstName")
                    .IsFixedLength();

                entity.Property(e => e.Identification)
                    .HasMaxLength(10)
                    .HasColumnName("identification")
                    .IsFixedLength();

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                entity.Property(e => e.LastName)
                    .HasMaxLength(10)
                    .HasColumnName("lastName")
                    .IsFixedLength();

                entity.Property(e => e.Nationality)
                    .HasMaxLength(10)
                    .HasColumnName("nationality")
                    .IsFixedLength();
            });

            modelBuilder.Entity<Hotel>(entity =>
            {
                entity.ToTable("Hotel");

                entity.Property(e => e.hotel_id).HasColumnName("hotel_id");

                entity.Property(e => e.HotelAddress)
                    .HasMaxLength(10)
                    .HasColumnName("hotelAddress")
                    .IsFixedLength();

                entity.Property(e => e.HotelContactNumber)
                    .HasMaxLength(10)
                    .HasColumnName("hotelContactNumber")
                    .IsFixedLength();

                entity.Property(e => e.HotelName)
                    .HasMaxLength(10)
                    .HasColumnName("hotelName")
                    .IsFixedLength();

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasColumnName("isActive")
                    .HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<Provider>(entity =>
            {
                entity.Property(e => e.provider_id).HasColumnName("provider_id");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasColumnName("isActive")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.ProviderAddress)
                    .HasMaxLength(10)
                    .HasColumnName("providerAddress")
                    .IsFixedLength();

                entity.Property(e => e.ProviderContactNumber)
                    .HasMaxLength(10)
                    .HasColumnName("providerContactNumber")
                    .IsFixedLength();

                entity.Property(e => e.ProviderEmail)
                    .HasMaxLength(10)
                    .HasColumnName("providerEmail")
                    .IsFixedLength();

                entity.Property(e => e.ProviderName)
                    .HasMaxLength(10)
                    .HasColumnName("providerName")
                    .IsFixedLength();

                entity.Property(e => e.ProviderPersonToContact)
                    .HasMaxLength(10)
                    .HasColumnName("providerPersonToContact")
                    .IsFixedLength();
            });

            modelBuilder.Entity<ProviderServiceType>(entity =>
            {
                entity.ToTable("ProviderServiceType");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ProviderId).HasColumnName("provider_id");

                entity.Property(e => e.ServiceTypeId).HasColumnName("serviceType_id");

                entity.HasOne(d => d.Provider)
                    .WithMany(p => p.ProviderServiceTypes)
                    .HasForeignKey(d => d.ProviderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProviderServiceType_Providers");

                entity.HasOne(d => d.ServiceType)
                    .WithMany(p => p.ProviderServiceTypes)
                    .HasForeignKey(d => d.ServiceTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProviderServiceType_ServiceType");
            });

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

            modelBuilder.Entity<ReservationHotel>(entity =>
            {
                entity.ToTable("reservationHotel");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CheckInDate)
                    .HasColumnType("date")
                    .HasColumnName("checkInDate");

                entity.Property(e => e.CheckInTime).HasColumnName("checkInTime");

                entity.Property(e => e.CheckOutDate)
                    .HasColumnType("datetime")
                    .HasColumnName("checkOutDate");

                entity.Property(e => e.HotelId).HasColumnName("hotel_id");

                entity.Property(e => e.ReservationId).HasColumnName("reservation_id");

                entity.HasOne(d => d.Hotel)
                    .WithMany(p => p.ReservationHotels)
                    .HasForeignKey(d => d.HotelId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_reservationHotel_Hotel");

                entity.HasOne(d => d.Reservation)
                    .WithMany(p => p.ReservationHotels)
                    .HasForeignKey(d => d.ReservationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Reservations_reservationHotel");
            });

            modelBuilder.Entity<ReservationTour>(entity =>
            {
                entity.ToTable("reservationTour");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.BookedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("bookedDate");

                entity.Property(e => e.ReservationId).HasColumnName("reservation_id");

                entity.Property(e => e.TourId).HasColumnName("tour_id");

                entity.HasOne(d => d.Reservation)
                    .WithMany(p => p.ReservationTours)
                    .HasForeignKey(d => d.ReservationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_reservationTour_Reservation");

                entity.HasOne(d => d.Tour)
                    .WithMany(p => p.ReservationTours)
                    .HasForeignKey(d => d.TourId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_reservationTour_Tours");
            });

            modelBuilder.Entity<ReservationTransport>(entity =>
            {
                entity.ToTable("reservationTransport");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.BookedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("bookedDate");

                entity.Property(e => e.ReservationId).HasColumnName("reservation_id");

                entity.Property(e => e.TransportId).HasColumnName("transport_id");

                entity.HasOne(d => d.Reservation)
                    .WithMany(p => p.ReservationTransports)
                    .HasForeignKey(d => d.ReservationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_reservationTransport_Reservation");

                entity.HasOne(d => d.Transport)
                    .WithMany(p => p.ReservationTransports)
                    .HasForeignKey(d => d.TransportId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_reservationTransport_Transport");
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

            modelBuilder.Entity<Transport>(entity =>
            {
                entity.ToTable("Transport");

                entity.HasIndex(e => e.TransportId, "IX_Transport")
                    .IsUnique();

                entity.Property(e => e.TransportId)
                    .ValueGeneratedNever()
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
                entity.ToTable("TransportType");

                entity.Property(e => e.TransportTypeId).HasColumnName("transportType_id");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasColumnName("isActive")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.TransportTypeName)
                    .HasMaxLength(10)
                    .HasColumnName("transportType")
                    .IsFixedLength();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
