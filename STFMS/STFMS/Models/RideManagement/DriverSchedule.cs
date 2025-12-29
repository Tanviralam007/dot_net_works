using STFMS.Models.UserManagement;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace STFMS.Models.RideManagement
{
    public class DriverSchedule
    {
        [Key]
        public int ScheduleID { get; set; }

        [Required]
        [ForeignKey("Driver")]
        public int DriverID { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime ShiftDate { get; set; }

        [Required]
        [DataType(DataType.Time)]
        public TimeSpan ShiftStartTime { get; set; }

        [Required]
        [DataType(DataType.Time)]
        public TimeSpan ShiftEndTime { get; set; }

        [Required]
        [StringLength(20)]
        public string AvailabilityStatus { get; set; } = "Available"; // Available, On Duty, Off Duty, On Leave

        // Navigation Property
        public virtual Driver? Driver { get; set; }
    }
}
