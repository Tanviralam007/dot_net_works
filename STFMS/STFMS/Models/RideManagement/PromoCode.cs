using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace STFMS.Models.RideManagement
{
    public class PromoCode
    {
        [Key]
        public int PromoID { get; set; }

        [Required]
        [StringLength(20)]
        public string? Code { get; set; }

        [Required]
        [StringLength(20)]
        public string? DiscountType { get; set; } // Percentage, Fixed

        [Required]
        [Column(TypeName = "decimal(8,2)")]
        public decimal DiscountValue { get; set; }

        [Column(TypeName = "decimal(8,2)")]
        public decimal? MaxDiscount { get; set; }

        [Column(TypeName = "decimal(8,2)")]
        public decimal? MinRideAmount { get; set; }

        [Required]
        public DateTime ValidFrom { get; set; }

        [Required]
        public DateTime ValidUntil { get; set; }

        public int? UsageLimit { get; set; }

        public int UsedCount { get; set; } = 0;

        public bool IsActive { get; set; } = true;

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        // Navigation Properties
        public virtual ICollection<Ride> Rides { get; set; } = new List<Ride>();
    }
}
