using Database_API.Models;
using Database_API.Models.DTOs;

namespace Database_API.Repositories;

public interface IAnimalRepository
{
    IEnumerable<Animal> GetAnimals(string orderBy);
    int CreateAnimal(Animal animal);
    void AddAnimal(AddAnimal animal);
}