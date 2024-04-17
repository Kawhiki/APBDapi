using Microsoft.AspNetCore.Mvc;

namespace APBDAPI.Controllers;


[ApiController]
[Route("animals")]
public class AnimalsController : ControllerBase
{
    private IAnimalDataAccess  _animalDataAccess;

    public AnimalsController(IAnimalDataAccess  animalDataAccess)
    {
        _animalDataAccess = animalDataAccess;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(_animalDataAccess.GetAllAnimals());
    }

    [HttpGet("{id}")]
    public IActionResult GetDetails(int id)
    {
        var animal = _animalDataAccess.GetDetailsOfAnimal(id);
        if (animal is null)
        {
            return NotFound();
        }
        return Ok(animal);
    }

    [HttpPost]
    public IActionResult Add(Animal animal)
    {
        _animalDataAccess.AddAnimal(animal);
        return Created($"animals/{animal.id}", animal);
    }
    
    [HttpPut("{id}")]
    public IActionResult Replace(int id, Animal animal)
    {
        if (_animalDataAccess.UpdateAnimal(id, animal) is null)
        {
            return NotFound();
        }
        return Ok(animal);
    }

    [HttpDelete("{id}")]
    public IActionResult Remove(int id)
    {
        var animal = _animalDataAccess.RemoveAnimal(id);
        return animal == null ? NotFound() : NoContent();
    }

    
    
}