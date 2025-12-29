using STFMS.Models.RideManagement;
using STFMS.Models.UserManagement;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace STFMS.Models.PaymentManagement
{
    public class Payment
    {
        [Key]
        public int PaymentID { get; set; }

        [Required]
        [ForeignKey("Ride")]
        public int RideID { get; set; }

        [Required]
        [ForeignKey("User")]
        public int UserID { get; set; }

        [Required]
        [Column(TypeName = "decimal(10,2)")]
        public decimal Amount { get; set; }

        [Required]
        [StringLength(30)]
        public string? PaymentMethod { get; set; } // Cash, Card, Wallet, Corporate Account

        [Required]
        [StringLength(20)]
        public string PaymentStatus { get; set; } = "Pending"; // Pending, Completed, Failed, Refunded

        [StringLength(100)]
        public string? TransactionID { get; set; }

        public DateTime PaymentDate { get; set; } = DateTime.Now;

        // Navigation Properties
        public virtual Ride? Ride { get; set; }
        public virtual User? User { get; set; }
    }
}
