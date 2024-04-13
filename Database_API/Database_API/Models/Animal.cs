using System.ComponentModel.DataAnnotations;

namespace Database_API.Models;

public class Animal
{
    // public int IdAnimal { get; set; }
    // [Required]
    // [MaxLength(199)]
    
    public string Name { get; set; }
    [MaxLength(199)]
    public string Description { get; set; }
    [Required]
    [MaxLength(199)]
    public string Category { get; set; }
    [MaxLength(199)]
    public string Area { get; set; }
}