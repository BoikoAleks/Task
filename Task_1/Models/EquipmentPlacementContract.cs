using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Task_1.Models
{
    public class EquipmentPlacementContract
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int ProductionFacilityCode { get; set; } // Change to int

        [Required]
        public int EquipmentTypeCode { get; set; } // Change to int

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Equipment quantity must be at least 1")]
        public int EquipmentQuantity { get; set; }

        // Navigation properties
        [ForeignKey(nameof(ProductionFacilityCode))]
        public ProductionFacility ProductionFacility { get; set; }

        [ForeignKey(nameof(EquipmentTypeCode))]
        public EquipmentType EquipmentType { get; set; }
    }
}
