using Database_API.Models;
using Database_API.Models.DTOs;
using Database_API.Repositories;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace Database_API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AnimalsController : ControllerBase
{
    private readonly IAnimalRepository _animalRepository;

    public AnimalsController(IAnimalRepository animalRepository)
    {
        _animalRepository = animalRepository;
    }
    
    [HttpGet]
    public IActionResult GetAnimals()
    {
        var animals = _animalRepository.GetAnimals();
         
        return Ok(animals);
    }

    // [HttpPost]
    // public IActionResult AddAnimal([FromBody] AddAnimal animal)
    // {
    //     using SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("Default"));
    //     connection.Open();
    //
    //     using SqlCommand command = new SqlCommand();
    //     command.Connection = connection;
    //     command.CommandText = "insert into Animal Values(@animalName, '', '', '')";
    //     command.Parameters.AddWithValue("@animalName", animal.Name);
    //
    //     command.ExecuteNonQuery();
    //
    //     return Created("", null);
    // }
}