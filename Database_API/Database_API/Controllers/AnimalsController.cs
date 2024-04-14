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
    public IActionResult GetAnimals(string orderBy="name")
    {
        var animals = _animalRepository.GetAnimals(orderBy);
        return Ok(animals);
    }

    [HttpPost]
    public IActionResult CreateAnimal([FromBody] Animal animal)
    {
        _animalRepository.CreateAnimal(animal);
        return StatusCode(StatusCodes.Status201Created);
    }

    [HttpPut("{animalid:int}")]
    public IActionResult UpdateAnimal([FromBody] Animal animal, int animalid)
    {
        _animalRepository.UpdateAnimal(animal, animalid);
        return StatusCode((StatusCodes.Status200OK));
    }

    [HttpDelete]
    public IActionResult DeleteAnimal(int animalid)
    {
        _animalRepository.DeleteAnimal(animalid);
        return StatusCode(StatusCodes.Status200OK);
    }
}