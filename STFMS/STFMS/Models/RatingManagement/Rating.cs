using STFMS.Models.RideManagement;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace STFMS.Models.RatingManagement
{
    public class Rating
    {
        [Key]
        public int RatingID { get; set; }

        [Required]
        [ForeignKey("Ride")]
        public int RideID { get; set; }

        [Required]
        [StringLength(20)]
        public string? RaterType { get; set; } // User, Driver

        [Required]
        public int RaterID { get; set; }

        [Required]
        [StringLength(20)]
        public string? RatedType { get; set; } // Driver, User

        [Required]
        public int RatedID { get; set; }

        [Required]
        [Range(1, 5)]
        [Column(TypeName = "decimal(2,1)")]
        public decimal RatingScore { get; set; }

        public string? Comment { get; set; }

        public DateTime RatingDate { get; set; } = DateTime.Now;

        // Navigation Property
        public virtual Ride? Ride { get; set; }
    }
}
