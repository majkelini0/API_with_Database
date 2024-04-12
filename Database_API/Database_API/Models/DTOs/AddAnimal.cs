using System.ComponentModel.DataAnnotations;

namespace Database_API.Models.DTOs;

public class AddAnimal
{
    [Required]
    [MinLength(5)]
    public string Name { get; set; }
    public string? Description { get; set; }
    public string Category { get; set; }
    public string Area { get; set; }
}