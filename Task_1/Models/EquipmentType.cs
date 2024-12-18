using System.ComponentModel.DataAnnotations;
using Task_1.Models;

public class EquipmentType
{
    [Key]
    public int Code { get; set; }

    [Required]
    public string Name { get; set; }

    [Required]
    public double Area { get; set; }

}

