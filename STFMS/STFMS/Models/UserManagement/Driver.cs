using STFMS.Models.RideManagement;
using STFMS.Models.VehicleManagement;
using STFMS.Models.PaymentManagement;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace STFMS.Models.UserManagement
{
    public class Driver
    {
        [Key]
        public int DriverID { get; set; }

        [Required]
        [StringLength(50)]
        public string? FirstName { get; set; }

        [Required]
        [StringLength(50)]
        public string? LastName { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(100)]
        public string? Email { get; set; }

        [Required]
        [Phone]
        [StringLength(20)]
        public string? PhoneNumber { get; set; }

        [Required]
        [StringLength(255)]
        public string? Password { get; set; }

        [Required]
        [StringLength(50)]
        public string? LicenseNumber { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime LicenseExpiryDate { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime HireDate { get; set; }

        [Required]
        [StringLength(20)]
        public string DriverStatus { get; set; } = "Active"; // Active, Inactive, On Leave, Suspended

        [Column(TypeName = "decimal(3,2)")]
        public decimal OverallRating { get; set; } = 5.00m;

        public int TotalRides { get; set; } = 0;

        [StringLength(255)]
        public string? ProfileImage { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        // Navigation Properties
        public virtual ICollection<Ride> Rides { get; set; } = new List<Ride>();
        public virtual ICollection<Vehicle> Vehicles { get; set; } = new List<Vehicle>();
        public virtual ICollection<DriverSchedule> Schedules { get; set; } = new List<DriverSchedule>();
        public virtual ICollection<DriverEarnings> Earnings { get; set; } = new List<DriverEarnings>();
    }
}
