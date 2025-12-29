using STFMS.Models.UserManagement;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace STFMS.Models.PaymentManagement
{
    public class Wallet
    {
        [Key]
        public int WalletID { get; set; }

        [Required]
        [ForeignKey("User")]
        public int UserID { get; set; }

        [Required]
        [Column(TypeName = "decimal(10,2)")]
        public decimal Balance { get; set; } = 0;

        [Required]
        [StringLength(3)]
        public string Currency { get; set; } = "GBP";

        public DateTime LastUpdated { get; set; } = DateTime.Now;

        // Navigation Properties
        public virtual User? User { get; set; }
        public virtual ICollection<WalletTransaction> Transactions { get; set; } = new List<WalletTransaction>();
    }
}
