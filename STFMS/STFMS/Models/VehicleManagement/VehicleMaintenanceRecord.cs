using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace STFMS.Models.VehicleManagement
{
    public class VehicleMaintenanceRecord
    {
        [Key]
        public int MaintenanceID { get; set; }

        [Required]
        [ForeignKey("Vehicle")]
        public int VehicleID { get; set; }

        [Required]
        [StringLength(20)]
        public string? MaintenanceType { get; set; } // Routine, Repair, Inspection, Emergency

        public string? Description { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime MaintenanceDate { get; set; }

        [Required]
        [Column(TypeName = "decimal(10,2)")]
        public decimal Cost { get; set; }

        [StringLength(100)]
        public string? ServiceProvider { get; set; }

        [DataType(DataType.Date)]
        public DateTime? NextScheduledDate { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal? MileageAtService { get; set; }

        [Required]
        [StringLength(20)]
        public string? Status { get; set; } // Scheduled, Completed, Pending

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        // Navigation Property
        public virtual Vehicle? Vehicle { get; set; }
    }
}
