using Microsoft.EntityFrameworkCore;
using STFMS.Models;
using STFMS.Models.UserManagement;
using STFMS.Models.VehicleManagement;
using STFMS.Models.RideManagement;
using STFMS.Models.PaymentManagement;
using STFMS.Models.RatingManagement;
using STFMS.Models.CorporateManagement;

namespace STFMS.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // User Management
        public DbSet<User> Users { get; set; }
        public DbSet<Driver> Drivers { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }
        public DbSet<EmergencyContact> EmergencyContacts { get; set; }

        // Vehicle Management
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<VehicleMaintenanceRecord> VehicleMaintenanceRecords { get; set; }
        public DbSet<VehicleLocation> VehicleLocations { get; set; }

        // Ride Management
        public DbSet<ServiceArea> ServiceAreas { get; set; }
        public DbSet<Fare> Fares { get; set; }
        public DbSet<PromoCode> PromoCodes { get; set; }
        public DbSet<Ride> Rides { get; set; }
        public DbSet<DriverSchedule> DriverSchedules { get; set; }

        // Payment Management
        public DbSet<Wallet> Wallets { get; set; }
        public DbSet<WalletTransaction> WalletTransactions { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<DriverEarnings> DriverEarnings { get; set; }

        // Rating Management
        public DbSet<Rating> Ratings { get; set; }
        public DbSet<Complaint> Complaints { get; set; }

        // Corporate Management
        public DbSet<CorporateClient> CorporateClients { get; set; }
        public DbSet<ParcelDelivery> ParcelDeliveries { get; set; }

        // Others
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Report> Reports { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure unique indexes
            modelBuilder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();

            modelBuilder.Entity<Driver>()
                .HasIndex(d => d.Email)
                .IsUnique();

            modelBuilder.Entity<Driver>()
                .HasIndex(d => d.LicenseNumber)
                .IsUnique();

            modelBuilder.Entity<Admin>()
                .HasIndex(a => a.Email)
                .IsUnique();

            modelBuilder.Entity<Vehicle>()
                .HasIndex(v => v.VIN)
                .IsUnique();

            modelBuilder.Entity<Vehicle>()
                .HasIndex(v => v.RegistrationNumber)
                .IsUnique();

            modelBuilder.Entity<RefreshToken>()
                .HasIndex(r => r.Token)
                .IsUnique();

            modelBuilder.Entity<PromoCode>()
                .HasIndex(p => p.Code)
                .IsUnique();

            modelBuilder.Entity<Payment>()
                .HasIndex(p => p.TransactionID)
                .IsUnique();

            modelBuilder.Entity<CorporateClient>()
                .HasIndex(c => c.Email)
                .IsUnique();

            // Configure composite indexes for performance
            modelBuilder.Entity<Ride>()
                .HasIndex(r => new { r.UserID, r.RideStatus });

            modelBuilder.Entity<Ride>()
                .HasIndex(r => new { r.DriverID, r.RideStatus });

            modelBuilder.Entity<VehicleLocation>()
                .HasIndex(vl => new { vl.VehicleID, vl.Timestamp });

            modelBuilder.Entity<DriverSchedule>()
                .HasIndex(ds => new { ds.DriverID, ds.ShiftDate });

            modelBuilder.Entity<WalletTransaction>()
                .HasIndex(wt => wt.WalletID);

            modelBuilder.Entity<DriverEarnings>()
                .HasIndex(de => new { de.DriverID, de.PayoutStatus });

            modelBuilder.Entity<Notification>()
                .HasIndex(n => new { n.RecipientType, n.RecipientID, n.IsRead });

            // Configure decimal precision
            modelBuilder.Entity<User>()
                .Property(u => u.OverallRating)
                .HasPrecision(3, 2);

            modelBuilder.Entity<Driver>()
                .Property(d => d.OverallRating)
                .HasPrecision(3, 2);

            modelBuilder.Entity<Rating>()
                .Property(r => r.RatingScore)
                .HasPrecision(2, 1);

            // Configure relationships with cascade delete behavior

            // Ride relationships
            modelBuilder.Entity<Ride>()
                .HasOne(r => r.User)
                .WithMany(u => u.Rides)
                .HasForeignKey(r => r.UserID)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Ride>()
                .HasOne(r => r.Driver)
                .WithMany(d => d.Rides)
                .HasForeignKey(r => r.DriverID)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Ride>()
                .HasOne(r => r.Vehicle)
                .WithMany(v => v.Rides)
                .HasForeignKey(r => r.VehicleID)
                .OnDelete(DeleteBehavior.SetNull);

            // Vehicle relationships
            modelBuilder.Entity<Vehicle>()
                .HasOne(v => v.Driver)
                .WithMany(d => d.Vehicles)
                .HasForeignKey(v => v.CurrentDriverID)
                .OnDelete(DeleteBehavior.SetNull);

            // Wallet relationships
            modelBuilder.Entity<Wallet>()
                .HasOne(w => w.User)
                .WithOne(u => u.Wallet)
                .HasForeignKey<Wallet>(w => w.UserID)
                .OnDelete(DeleteBehavior.Cascade);

            // ParcelDelivery relationships
            modelBuilder.Entity<ParcelDelivery>()
                .HasOne(pd => pd.Ride)
                .WithOne(r => r.ParcelDelivery)
                .HasForeignKey<ParcelDelivery>(pd => pd.RideID)
                .OnDelete(DeleteBehavior.Cascade);

            // Payment relationships
            modelBuilder.Entity<Payment>()
                .HasOne(p => p.User)
                .WithMany(u => u.Payments)
                .HasForeignKey(p => p.UserID)
                .OnDelete(DeleteBehavior.NoAction);  // Changed from Cascade to NoAction

            modelBuilder.Entity<Payment>()
                .HasOne(p => p.Ride)
                .WithMany(r => r.Payments)
                .HasForeignKey(p => p.RideID)
                .OnDelete(DeleteBehavior.Cascade);

            // DriverEarnings relationships
            modelBuilder.Entity<DriverEarnings>()
                .HasOne(de => de.Driver)
                .WithMany(d => d.Earnings)
                .HasForeignKey(de => de.DriverID)
                .OnDelete(DeleteBehavior.NoAction);  // Changed from Cascade to NoAction

            modelBuilder.Entity<DriverEarnings>()
                .HasOne(de => de.Ride)
                .WithMany()
                .HasForeignKey(de => de.RideID)
                .OnDelete(DeleteBehavior.Cascade);

            // Rating relationships
            modelBuilder.Entity<Rating>()
                .HasOne(r => r.Ride)
                .WithMany(ride => ride.Ratings)
                .HasForeignKey(r => r.RideID)
                .OnDelete(DeleteBehavior.Cascade);

            // Configure check constraints
            modelBuilder.Entity<Rating>()
                .ToTable(t => t.HasCheckConstraint("CK_Rating_Score", "[RatingScore] >= 1 AND [RatingScore] <= 5"));

            // Seed initial data
            SeedData(modelBuilder);
        }

        private void SeedData(ModelBuilder modelBuilder)
        {
            // Seed Admin
            modelBuilder.Entity<Admin>().HasData(
                new Admin
                {
                    AdminID = 1,
                    FirstName = "Super",
                    LastName = "Admin",
                    Email = "admin@superrides.com",
                    PhoneNumber = "+44 20 1234 5678",
                    Password = "HashedPassword123", 
                    Role = "SuperAdmin",
                    Status = "Active",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                }
            );

            // Seed Service Areas
            modelBuilder.Entity<ServiceArea>().HasData(
                new ServiceArea { AreaID = 1, CityName = "London", AreaName = "Central London", Latitude = 51.5074m, Longitude = -0.1278m, IsActive = true },
                new ServiceArea { AreaID = 2, CityName = "Manchester", AreaName = "Manchester City Centre", Latitude = 53.4808m, Longitude = -2.2426m, IsActive = true },
                new ServiceArea { AreaID = 3, CityName = "Birmingham", AreaName = "Birmingham City Centre", Latitude = 52.4862m, Longitude = -1.8904m, IsActive = true },
                new ServiceArea { AreaID = 4, CityName = "Glasgow", AreaName = "Glasgow City Centre", Latitude = 55.8642m, Longitude = -4.2518m, IsActive = true }
            );

            // Seed Fares
            modelBuilder.Entity<Fare>().HasData(
                new Fare
                {
                    FareID = 1,
                    ServiceType = "Passenger",
                    VehicleType = "Sedan",
                    BaseFare = 5.00m,
                    PerKilometerRate = 1.50m,
                    PerMinuteRate = 0.30m,
                    MinimumFare = 7.00m,
                    EffectiveDate = new DateTime(2024, 1, 1),
                    IsActive = true
                },
                new Fare
                {
                    FareID = 2,
                    ServiceType = "Passenger",
                    VehicleType = "SUV",
                    BaseFare = 7.00m,
                    PerKilometerRate = 2.00m,
                    PerMinuteRate = 0.40m,
                    MinimumFare = 10.00m,
                    EffectiveDate = new DateTime(2024, 1, 1),
                    IsActive = true
                }
            );
        }
    }
}