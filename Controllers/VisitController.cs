using Microsoft.AspNetCore.Mvc;
using rest_api_lec.Models;

namespace rest_api_lec.Controllers;

[Route("api/visits")]
[ApiController]
public class VisitController : ControllerBase
{
    private static readonly List<Visit> _visits = new()
    {
        new Visit
        {
            Date = new DateTime(2024, 3, 4),
            AnimalId = 1,
            Description = "Boli ogon",
            Price = 10.4
        },
        new Visit
        {
            Date = new DateTime(2024, 4, 3),
            AnimalId = 3,
            Description = "Boli zab",
            Price = 23.1
        },
        new Visit
        {
            Date = new DateTime(2024, 5, 1),
            AnimalId = 2,
            Description = "lysienie",
            Price = 5.1
        }
    };

    [HttpGet("{animalId:int}")]
    public IActionResult GetVisits(int animalId)
    {
        List<Visit> result = new List<Visit>();
        foreach (var visit in _visits)
        {
            if (visit.AnimalId == animalId)
            {
                result.Add(visit);
            }
        }

        if (result.Count == 0)
        {
            return NotFound($"Visit for animal with id {animalId} was not found");
        }

        return Ok(result);
    }

    [HttpPost]
    public IActionResult CreateVisit(Visit visit)
    {
        _visits.Add(visit);
        return StatusCode(StatusCodes.Status201Created);
    }
}