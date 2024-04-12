namespace Database_API.Models;

public class Animal
{
    public int IdAnimal { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Category { get; set; }
    public string Area { get; set; }
    /*
     * Description NVARCHAR(200) NULL,
Category NVARCHAR(200),
Area NVARCHAR(200),
     */
}