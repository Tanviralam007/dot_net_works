using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace STFMS.Models.UserManagement
{
    public class EmergencyContact
    {
        [Key]
        public int ContactID { get; set; }

        [Required]
        [ForeignKey("User")]
        public int UserID { get; set; }

        [Required]
        [StringLength(100)]
        public string? ContactName { get; set; }

        [Required]
        [Phone]
        [StringLength(20)]
        public string? ContactPhone { get; set; }

        [StringLength(50)]
        public string? Relationship { get; set; }

        public bool IsPrimary { get; set; } = false;

        // Navigation Property
        public virtual User? User { get; set; }
    }
}
