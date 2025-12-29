using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace STFMS.Models.RideManagement
{
    public class Fare
    {
        [Key]
        public int FareID { get; set; }

        [Required]
        [StringLength(20)]
        public string? ServiceType { get; set; } // Passenger, Corporate, Parcel

        [Required]
        [StringLength(20)]
        public string? VehicleType { get; set; } // Sedan, SUV, Van, Bike

        [Required]
        [Column(TypeName = "decimal(8,2)")]
        public decimal BaseFare { get; set; }

        [Required]
        [Column(TypeName = "decimal(8,2)")]
        public decimal PerKilometerRate { get; set; }

        [Required]
        [Column(TypeName = "decimal(8,2)")]
        public decimal PerMinuteRate { get; set; }

        [Required]
        [Column(TypeName = "decimal(8,2)")]
        public decimal MinimumFare { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime EffectiveDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime? ExpiryDate { get; set; }

        public bool IsActive { get; set; } = true;

        // Navigation Properties
        public virtual ICollection<Ride> Rides { get; set; } = new List<Ride>();
    }
}
