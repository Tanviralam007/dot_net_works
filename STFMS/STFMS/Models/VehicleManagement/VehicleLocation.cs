using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace STFMS.Models.VehicleManagement
{
    public class VehicleLocation
    {
        [Key]
        public int LocationID { get; set; }

        [Required]
        [ForeignKey("Vehicle")]
        public int VehicleID { get; set; }

        [Required]
        [Column(TypeName = "decimal(10,8)")]
        public decimal Latitude { get; set; }

        [Required]
        [Column(TypeName = "decimal(11,8)")]
        public decimal Longitude { get; set; }

        [Column(TypeName = "decimal(5,2)")]
        public decimal? Speed { get; set; }

        public DateTime Timestamp { get; set; } = DateTime.Now;

        // Navigation Property
        public virtual Vehicle? Vehicle { get; set; }
    }
}
