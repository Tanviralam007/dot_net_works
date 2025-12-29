using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace STFMS.Models.CorporateManagement
{
    public class CorporateClient
    {
        [Key]
        public int ClientID { get; set; }

        [Required]
        [StringLength(100)]
        public string? CompanyName { get; set; }

        [Required]
        [StringLength(100)]
        public string? ContactPerson { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(100)]
        public string? Email { get; set; }

        [Required]
        [Phone]
        [StringLength(20)]
        public string? PhoneNumber { get; set; }

        [StringLength(255)]
        public string? Address { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime ContractStartDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime? ContractEndDate { get; set; }

        [Column(TypeName = "decimal(5,2)")]
        public decimal DiscountRate { get; set; } = 0;

        public bool MonthlyInvoice { get; set; } = true;

        [Required]
        [StringLength(20)]
        public string AccountStatus { get; set; } = "Active"; // Active, Suspended, Expired

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}
