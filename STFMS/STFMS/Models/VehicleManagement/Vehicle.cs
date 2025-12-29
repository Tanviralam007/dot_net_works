using STFMS.Models.RideManagement;
using STFMS.Models.UserManagement;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace STFMS.Models.VehicleManagement
{
    public class Vehicle
    {
        [Key]
        public int VehicleID { get; set; }

        [Required]
        [StringLength(17)]
        public string? VIN { get; set; }

        [Required]
        [StringLength(20)]
        public string? RegistrationNumber { get; set; }

        [Required]
        [StringLength(50)]
        public string? Make { get; set; }

        [Required]
        [StringLength(50)]
        public string? Model { get; set; }

        [Required]
        public int Year { get; set; }

        [StringLength(30)]
        public string? Color { get; set; }

        [Required]
        public int Capacity { get; set; }

        [Required]
        [StringLength(20)]
        public string? VehicleType { get; set; } // Sedan, SUV, Van, Bike

        [Required]
        [StringLength(20)]
        public string? FuelType { get; set; } // Petrol, Diesel, Electric, Hybrid

        [ForeignKey("Driver")]
        public int? CurrentDriverID { get; set; }

        [Required]
        [StringLength(20)]
        public string CurrentStatus { get; set; } = "Available"; // Available, In Use, Maintenance, Out of Service

        [DataType(DataType.Date)]
        public DateTime? PurchaseDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime? LastMaintenanceDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime? NextMaintenanceDate { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal Mileage { get; set; } = 0;

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        // Navigation Properties
        public virtual Driver? Driver { get; set; }
        public virtual ICollection<Ride> Rides { get; set; } = new List<Ride>();
        public virtual ICollection<VehicleMaintenanceRecord> MaintenanceRecords { get; set; } = new List<VehicleMaintenanceRecord>();
        public virtual ICollection<VehicleLocation> Locations { get; set; } = new List<VehicleLocation>();
    }
}
