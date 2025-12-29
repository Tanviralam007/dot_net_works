using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace STFMS.Models.PaymentManagement
{
    public class WalletTransaction
    {
        [Key]
        public int TransactionID { get; set; }

        [Required]
        [ForeignKey("Wallet")]
        public int WalletID { get; set; }

        [Required]
        [StringLength(20)]
        public string? TransactionType { get; set; } // Credit, Debit, Refund

        [Required]
        [Column(TypeName = "decimal(10,2)")]
        public decimal Amount { get; set; }

        [Required]
        [Column(TypeName = "decimal(10,2)")]
        public decimal BalanceBefore { get; set; }

        [Required]
        [Column(TypeName = "decimal(10,2)")]
        public decimal BalanceAfter { get; set; }

        [StringLength(20)]
        public string? ReferenceType { get; set; } // Ride, TopUp, Refund, Promo

        public int? ReferenceID { get; set; }

        [StringLength(255)]
        public string? Description { get; set; }

        public DateTime TransactionDate { get; set; } = DateTime.Now;

        // Navigation Property
        public virtual Wallet? Wallet { get; set; }
    }
}
