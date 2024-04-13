using Database_API.Models;
using Database_API.Models.DTOs;
using Microsoft.Data.SqlClient;

namespace Database_API.Repositories;

public class AnimalRepository : IAnimalRepository
{
    private readonly IConfiguration _configuration;

    public AnimalRepository(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    
    public IEnumerable<Animal> GetAnimals(string orderBy)
    {
        if (!IsValidSortColumn(orderBy))
            throw new ArgumentException("Invalid sortBy parameter");
        
        // otwieranie polaczenia
        using SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("Default"));
        connection.Open();
        // definicja polecenia
        using SqlCommand command = new SqlCommand();
        command.Connection = connection;
        command.CommandText = $"SELECT * FROM Animal ORDER BY {orderBy} ASC";
        // command.Parameters.AddWithValue("@sortBy", sortBy); tylko dla WHERE i JOIN

        // wykonanie polecenia
        var reader = command.ExecuteReader();
        var animals = new List<Animal>();

        //int idAnimalOrdinal = reader.GetOrdinal("IdAnimal");
        int nameOrdinal = reader.GetOrdinal("Name");
        int descriptionOrdinal = reader.GetOrdinal("Description");
        int categoryOrdinal = reader.GetOrdinal("Category");
        int areaOrdinal = reader.GetOrdinal("Area");
        
        while (reader.Read())
        {
            animals.Add(new Animal()
            {
                //IdAnimal = reader.GetInt32(idAnimalOrdinal),
                Name = reader.GetString(nameOrdinal),
                Description = reader.GetString(descriptionOrdinal),
                Category = reader.GetString(categoryOrdinal),
                Area = reader.GetString(areaOrdinal)
            });
        }
        return animals;
    }

    public int CreateAnimal(Animal animal)
    {
        using SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("Default"));
        connection.Open();
        using SqlCommand command = new SqlCommand();
        command.Connection = connection;
        command.CommandText = "INSERT INTO Animal VALUES (@Name, @Description, @Category, @Area)";
        command.Parameters.AddWithValue("@Name", animal.Name);
        command.Parameters.AddWithValue("@Description", animal.Description);
        command.Parameters.AddWithValue("@Category", animal.Category);
        command.Parameters.AddWithValue("@Area", animal.Area);

        var affectedCount = command.ExecuteNonQuery();
        return affectedCount;
    }

    public void AddAnimal(AddAnimal animal)
    {
        throw new NotImplementedException();
    }
    
    private bool IsValidSortColumn(string column)
    {
        // Lista dozwolonych kolumn
        List<string> validColumns = new List<string> { "name", "description", "category", "area" };

        // Sprawdź, czy sortBy znajduje się na liście dozwolonych kolumn
        return validColumns.Contains(column);
    }
}