using Microsoft.AspNetCore.Mvc;
using rest_api_lec.Models;

namespace rest_api_lec.Controllers;

[Route("api/animals")]
[ApiController]
public class AnimalController : ControllerBase
{
    private static readonly List<Animal> _animals = new()
    {
        new Animal
        {
            Id = 1,
            Name = "Spike",
            Type = "Dog",
            Weight = 20.4,
            Color = "Gray"
        },

        new Animal
        {
            Id = 2,
            Name = "Oskar",
            Type = "Dog",
            Weight = 14.7,
            Color = "Black"
        },
        new Animal
        {
            Id = 3,
            Name = "Barsik",
            Type = "Cat",
            Weight = 5.7,
            Color = "White"
        },
        new Animal
        {
            Id = 4,
            Name = "Roy",
            Type = "Bird",
            Weight = 0.3,
            Color = "Blue"
        },
    };

    [HttpGet]
    public IActionResult GetAnimal()
    {
        return Ok(_animals);
    }

    [HttpGet("{id:int}")]
    public IActionResult GetAnimal(int id)
    {
        var animal = _animals.FirstOrDefault(an => an.Id == id);
        if (animal == null)
        {
            return NotFound($"Animal with id {id} was not found");
        }

        return Ok(animal);
    }

    [HttpPost]
    public IActionResult CreateAnimal(Animal animal)
    {
        _animals.Add(animal);
        return StatusCode(StatusCodes.Status201Created);
    }

    [HttpPut("{id:int}")]
    public IActionResult UpdateAnimal(int id, Animal animal)
    {
        var animalToEdit = _animals.FirstOrDefault(an => an.Id == id);

        if (animalToEdit == null)
        {
            return NotFound($"Animal with id {id} was not found");
        }

        _animals.Remove(animalToEdit);
        _animals.Add(animal);
        return NoContent();
    }


    [HttpDelete("{id:int}")]
    public IActionResult DeleteStudent(int id)
    {
        var animalToDelete = _animals.FirstOrDefault(an => an.Id == id);
        if (animalToDelete == null)
        {
            return NoContent();
        }

        _animals.Remove(animalToDelete);
        return NoContent();
    }
}