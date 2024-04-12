using Database_API.Models;
using Database_API.Models.DTOs;

namespace Database_API.Repositories;

public interface IAnimalRepository
{
    IEnumerable<Animal> GetAnimals();
    void AddAnimal(AddAnimal animal);
}