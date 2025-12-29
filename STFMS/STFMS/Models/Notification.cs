using System.ComponentModel.DataAnnotations;

namespace STFMS.Models
{
    public class Notification
    {
        [Key]
        public int NotificationID { get; set; }

        [Required]
        [StringLength(20)]
        public string? RecipientType { get; set; } // User, Driver, Admin

        [Required]
        public int RecipientID { get; set; }

        [Required]
        [StringLength(50)]
        public string? NotificationType { get; set; } // Ride Update, Payment, Promotion, System Alert, Emergency

        [Required]
        [StringLength(100)]
        public string? Title { get; set; }

        [Required]
        public string? Message { get; set; }

        public bool IsRead { get; set; } = false;

        public DateTime SentDate { get; set; } = DateTime.Now;
    }
}
