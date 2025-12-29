using STFMS.Models.RideManagement;
using STFMS.Models.UserManagement;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace STFMS.Models.PaymentManagement
{
    public class DriverEarnings
    {
        [Key]
        public int EarningID { get; set; }

        [Required]
        [ForeignKey("Driver")]
        public int DriverID { get; set; }

        [Required]
        [ForeignKey("Ride")]
        public int RideID { get; set; }

        [Required]
        [Column(TypeName = "decimal(10,2)")]
        public decimal TotalFare { get; set; }

        [Required]
        [Column(TypeName = "decimal(5,2)")]
        public decimal CommissionRate { get; set; }

        [Required]
        [Column(TypeName = "decimal(10,2)")]
        public decimal CommissionAmount { get; set; }

        [Required]
        [Column(TypeName = "decimal(10,2)")]
        public decimal DriverAmount { get; set; }

        [Required]
        [StringLength(20)]
        public string PayoutStatus { get; set; } = "Pending"; // Pending, Processed, Paid

        [DataType(DataType.Date)]
        public DateTime? PayoutDate { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        // Navigation Properties
        public virtual Driver? Driver { get; set; }
        public virtual Ride? Ride { get; set; }
    }
}
