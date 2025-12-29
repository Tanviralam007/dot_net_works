using STFMS.Models.UserManagement;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace STFMS.Models
{
    public class Report
    {
        [Key]
        public int ReportID { get; set; }

        [Required]
        [StringLength(50)]
        public string? ReportType { get; set; } // Revenue, Driver Performance, Fleet Utilization, Customer Satisfaction

        [Required]
        [ForeignKey("Admin")]
        public int GeneratedBy { get; set; }

        public DateTime GeneratedDate { get; set; } = DateTime.Now;

        [Required]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }

        [Column(TypeName = "nvarchar(max)")]
        public string? ReportData { get; set; }

        [StringLength(255)]
        public string? FilePath { get; set; }

        // Navigation Property
        public virtual Admin? Admin { get; set; }
    }
}
