using STFMS.Models.RideManagement;
using STFMS.Models.UserManagement;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace STFMS.Models.RatingManagement
{
    public class Complaint
    {
        [Key]
        public int ComplaintID { get; set; }

        [ForeignKey("User")]
        public int? UserID { get; set; }

        [ForeignKey("Driver")]
        public int? DriverID { get; set; }

        [ForeignKey("Ride")]
        public int? RideID { get; set; }

        [Required]
        [StringLength(50)]
        public string? ComplaintType { get; set; } // Service Quality, Payment Issue, Driver Behavior, Vehicle Condition, Safety, Other

        [Required]
        public string? Description { get; set; }

        public DateTime ComplaintDate { get; set; } = DateTime.Now;

        [Required]
        [StringLength(20)]
        public string Status { get; set; } = "Open"; // Open, Under Review, Resolved, Closed

        [Required]
        [StringLength(20)]
        public string Priority { get; set; } = "Medium"; // Low, Medium, High, Critical

        public string? Resolution { get; set; }

        [ForeignKey("Admin")]
        public int? ResolvedBy { get; set; }

        public DateTime? ResolvedDate { get; set; }

        // Navigation Properties
        public virtual User? User { get; set; }
        public virtual Driver? Driver { get; set; }
        public virtual Ride? Ride { get; set; }
        public virtual Admin? Admin { get; set; }
    }
}
