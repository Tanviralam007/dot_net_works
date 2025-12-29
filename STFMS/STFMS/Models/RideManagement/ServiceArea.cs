using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace STFMS.Models.RideManagement
{
    public class ServiceArea
    {
        [Key]
        public int AreaID { get; set; }

        [Required]
        [StringLength(50)]
        public string? CityName { get; set; }

        [Required]
        [StringLength(100)]
        public string? AreaName { get; set; }

        [Required]
        [Column(TypeName = "decimal(10,8)")]
        public decimal Latitude { get; set; }

        [Required]
        [Column(TypeName = "decimal(11,8)")]
        public decimal Longitude { get; set; }

        public bool IsActive { get; set; } = true;
    }
}
