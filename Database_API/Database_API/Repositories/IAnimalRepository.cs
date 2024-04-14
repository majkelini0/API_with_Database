using Database_API.Models;
using Database_API.Models.DTOs;

namespace Database_API.Repositories;

public interface IAnimalRepository
{
    IEnumerable<AnimalWithId> GetAnimals(string orderBy);
    int CreateAnimal(Animal animal);
    int UpdateAnimal(Animal animal, int animalid);
    int DeleteAnimal(int animalid);
}