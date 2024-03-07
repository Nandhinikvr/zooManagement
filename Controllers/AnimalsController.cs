using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ZooManagement.Enums;
using ZooManagement.Models.Data;
using ZooManagement.Models.Request;

namespace ZooManagement.Controllers;

[ApiController]
[Route("/animals")]
public class AnimalsController : Controller
{
    private readonly Zoo _zoo;

    public AnimalsController(Zoo zoo)
    {
        _zoo = zoo;
    }
    
    private static AnimalResponse AnimalToResponse(Animal animal)
    {
        return new AnimalResponse
            {
                Name = animal.Name, 
                SpeciesName = animal.Species.Name, // animal.Species? 【Species defaul as null! ==> need eager loading
                Classification = animal.Species.Classification.ToString().ToLower(), // .Include(animal => animal.Species)
                Sex = animal.Sex.ToString().ToLower(),
                DateOfBirth = animal.DateOfBirth,
                DateOfAcquisition = animal.DateOfAcquisition,
            };
    }

    [HttpGet("{id}")]
    public IActionResult GetById([FromRoute] int id)
    {
        var matchingAnimal = _zoo.Animals
            .Include(animal => animal.Species)
            .SingleOrDefault(animal => animal.Id == id);
        if (matchingAnimal == null)
        {
            return NotFound();
        }
        return Ok(new AnimalResponse
        {
            Name = matchingAnimal.Name,
            SpeciesName = matchingAnimal.Species.Name,
            Classification = matchingAnimal.Species.Classification.ToString().ToLower(),
            Sex = matchingAnimal.Sex.ToString().ToLower(),
            DateOfBirth = matchingAnimal.DateOfBirth,
            DateOfAcquisition = matchingAnimal.DateOfAcquisition,
        });
    }

    [HttpPost("Add-a-animal")]
    public IActionResult Create([FromBody] CreateAnimalRequest createAnimalRequest)
    {
        var newAnimal = _zoo.Animals.Add(new Animal
        {
            Name = createAnimalRequest.Name,
            SpeciesId = createAnimalRequest.SpeciesId,
            Sex = createAnimalRequest.Sex,
            DateOfBirth = createAnimalRequest.DateOfBirth,
            DateOfAcquisition = createAnimalRequest.DateOfAcquisition,
        }).Entity;
        _zoo.SaveChanges();
        return Ok(newAnimal);
    }

     [HttpGet("list-all")]
    public IActionResult ListAll()
    {
        var animals = new List<AnimalResponse> {};
        foreach (var animal in _zoo.Animals.Include(animal => animal.Species))
        {
            animals.Add(AnimalToResponse(animal));
        }

        return Ok(animals);
    }
     [HttpGet("search")]
    public IActionResult Search([FromQuery] SearchAnimalRequest searchAnimalRequest)
    {
        var query = _zoo.Animals.Include(animal => animal.Species).AsQueryable();
        if (!string.IsNullOrEmpty(searchAnimalRequest.Name))
        {
            query = query.Where(animal => animal.Name.Contains(searchAnimalRequest.Name));
        }

        if (!string.IsNullOrEmpty(searchAnimalRequest.SpeciesName))
        {
            query = query.Where(animal => animal.Species.Name.Contains(searchAnimalRequest.SpeciesName));
        }

        if (!string.IsNullOrEmpty(searchAnimalRequest.ClassificationName))
        { 
            if (Enum.TryParse<Classification>(searchAnimalRequest.ClassificationName, ignoreCase: true, out var classification))
            {
                query = query.Where(animal => animal.Species.Classification == classification);
            }
            else
            {
                query = Enumerable.Empty<Animal>().AsQueryable();
            }
        }

        if (!string.IsNullOrEmpty(searchAnimalRequest.SexName))
        { 
            if (Enum.TryParse<Sex>(searchAnimalRequest.SexName, ignoreCase: true, out var sex))
            {
                query = query.Where(animal => animal.Sex == sex);
            }
            else
            {
                query = Enumerable.Empty<Animal>().AsQueryable();
            }
        }

        var searchResult = query.ToList();

        return Ok(searchResult);
    }
}
