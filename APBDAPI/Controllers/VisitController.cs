using Microsoft.AspNetCore.Mvc;


namespace APBDAPI.Controllers;

[ApiController]
[Route("Visits")]
public class VisitsController : ControllerBase
{
    private IAnimalDataAccess  _animalDataAccess;

    public VisitsController(IAnimalDataAccess  animalDataAccess)
    {
        _animalDataAccess = animalDataAccess;
    }

    [HttpGet("{Animal_id}")]
    public IActionResult GetVisits(int Animal_id)
    {
        var visits = _animalDataAccess.GetVisitsByAnimalId(Animal_id) ?? new List<Visit>();
        return Ok(visits);
    }


    [HttpPost]
    public IActionResult Add(Visit visit)
    {
        _animalDataAccess.AddVisit(visit);
        return Created($"visits/{visit.Id}", visit);
    }
    
}