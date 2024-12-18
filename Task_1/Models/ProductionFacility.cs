using System.ComponentModel.DataAnnotations;

namespace Task_1.Models
{
    public class ProductionFacility
    {

        [Key]
        [Required]
        public int Code { get; set; }

        [Required]
        public string Name { get; set; }

        public double StandardArea { get; set; }

      
    }
}
