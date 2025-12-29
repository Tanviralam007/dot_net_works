using STFMS.Models.CorporateManagement;
using STFMS.Models.UserManagement;
using STFMS.Models.VehicleManagement;
using STFMS.Models.PaymentManagement;
using STFMS.Models.RatingManagement;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace STFMS.Models.RideManagement
{
    public class Ride
    {
        [Key]
        public int RideID { get; set; }

        [Required]
        [ForeignKey("User")]
        public int UserID { get; set; }

        [ForeignKey("Driver")]
        public int? DriverID { get; set; }

        [ForeignKey("Vehicle")]
        public int? VehicleID { get; set; }

        [Required]
        [StringLength(20)]
        public string? ServiceType { get; set; } // Passenger, Corporate, Parcel

        // Pickup Details
        [Required]
        [Column(TypeName = "decimal(10,8)")]
        public decimal PickupLatitude { get; set; }

        [Required]
        [Column(TypeName = "decimal(11,8)")]
        public decimal PickupLongitude { get; set; }

        [Required]
        [StringLength(255)]
        public string? PickupAddress { get; set; }

        // Dropoff Details
        [Required]
        [Column(TypeName = "decimal(10,8)")]
        public decimal DropoffLatitude { get; set; }

        [Required]
        [Column(TypeName = "decimal(11,8)")]
        public decimal DropoffLongitude { get; set; }

        [Required]
        [StringLength(255)]
        public string? DropoffAddress { get; set; }

        // Timing
        public DateTime RequestTime { get; set; } = DateTime.Now;
        public DateTime? AcceptedTime { get; set; }
        public DateTime? PickupTime { get; set; }
        public DateTime? DropoffTime { get; set; }

        // Distance & Duration
        [Column(TypeName = "decimal(8,2)")]
        public decimal? EstimatedDistance { get; set; }

        [Column(TypeName = "decimal(8,2)")]
        public decimal? ActualDistance { get; set; }

        public int? EstimatedDuration { get; set; }
        public int? ActualDuration { get; set; }

        // Pricing
        [ForeignKey("Fare")]
        public int? FareID { get; set; }

        [ForeignKey("PromoCode")]
        public int? PromoID { get; set; }

        [Column(TypeName = "decimal(8,2)")]
        public decimal? BaseFare { get; set; }

        [Column(TypeName = "decimal(8,2)")]
        public decimal SurgeFare { get; set; } = 0;

        [Column(TypeName = "decimal(8,2)")]
        public decimal DiscountAmount { get; set; } = 0;

        [Column(TypeName = "decimal(8,2)")]
        public decimal TipAmount { get; set; } = 0;

        [Column(TypeName = "decimal(8,2)")]
        public decimal? TotalFare { get; set; }

        // Status & Cancellation
        [Required]
        [StringLength(20)]
        public string RideStatus { get; set; } = "Requested"; // Requested, Accepted, Arrived, InProgress, Completed, Cancelled

        [StringLength(20)]
        public string? CancelledBy { get; set; } // User, Driver, System

        public DateTime? CancelledAt { get; set; }
        public string? CancellationReason { get; set; }

        // Navigation Properties
        public virtual User? User { get; set; }
        public virtual Driver? Driver { get; set; }
        public virtual Vehicle? Vehicle { get; set; }
        public virtual Fare? Fare { get; set; }
        public virtual PromoCode? PromoCode { get; set; }
        public virtual ICollection<Rating> Ratings { get; set; } = new List<Rating>();
        public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();
        public virtual ParcelDelivery? ParcelDelivery { get; set; }
    }
}
