using STFMS.Models.RideManagement;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace STFMS.Models.CorporateManagement
{
    public class ParcelDelivery
    {
        [Key]
        public int ParcelID { get; set; }

        [Required]
        [ForeignKey("Ride")]
        public int RideID { get; set; }

        [Required]
        [StringLength(100)]
        public string? SenderName { get; set; }

        [Required]
        [Phone]
        [StringLength(20)]
        public string? SenderPhone { get; set; }

        [Required]
        [StringLength(100)]
        public string? ReceiverName { get; set; }

        [Required]
        [Phone]
        [StringLength(20)]
        public string? ReceiverPhone { get; set; }

        public string? PackageDescription { get; set; }

        [Column(TypeName = "decimal(8,2)")]
        public decimal? PackageWeight { get; set; }

        public string? SpecialInstructions { get; set; }

        [Required]
        [StringLength(20)]
        public string DeliveryStatus { get; set; } = "Pending"; // Pending, Picked Up, In Transit, Delivered, Failed

        [StringLength(20)]
        public string? DeliveryProofType { get; set; } // Signature, Photo, OTP

        [StringLength(255)]
        public string? DeliveryProofData { get; set; }

        public DateTime? DeliveredAt { get; set; }

        // Navigation Property
        public virtual Ride? Ride { get; set; }
    }
}
