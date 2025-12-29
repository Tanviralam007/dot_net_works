using System.ComponentModel.DataAnnotations;

namespace STFMS.Models.UserManagement
{
    public class RefreshToken
    {
        [Key]
        public int TokenID { get; set; }

        [Required]
        [StringLength(20)]
        public string? UserType { get; set; } // User, Driver, Admin

        [Required]
        public int UserID { get; set; }

        [Required]
        [StringLength(255)]
        public string? Token { get; set; }

        [Required]
        public DateTime ExpiryDate { get; set; }

        public bool IsRevoked { get; set; } = false;

        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
