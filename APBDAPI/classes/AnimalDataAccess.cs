namespace APBDAPI;

public interface IAnimalDataAccess 
{
    public ICollection<Animal> GetAllAnimals();
    public bool AddAnimal(Animal animal);
    public Animal? RemoveAnimal(int id);
    public Animal? GetDetailsOfAnimal(int id);
    public Animal? UpdateAnimal(int id, Animal updatedAnimal);
    //
    public ICollection<Visit> GetVisitsByAnimalId(int animalID);
    public bool AddVisit(Visit visit);

}

public class AnimalDataAccess : IAnimalDataAccess 
{
    private ICollection<Animal> _animals;
    private ICollection<Visit> _visits;

    public AnimalDataAccess()
    {
        _animals = new List<Animal>
        {
            new Animal { id = 1, category = "Dog", hair_colour = "Golden", name = "Buddy", Weight = 30.2 },
            new Animal { id = 2, category = "Bird", hair_colour = "Green", name = "Kiwi", Weight = 0.15 },
            new Animal { id = 3, category = "Snake", hair_colour = "Red", name = "Viper", Weight = 2.5 },
        };
        _visits = new List<Visit>
        {
            new Visit
            {
                Id = 1, Animal = _animals.First(a => a.id == 1), DateOfVisit = DateTime.Parse("2024-04-15"),
                Description = "Annual vaccination", Cost = 120.00m
            },
            new Visit
            {
                Id = 2, Animal = _animals.First(a => a.id == 2), DateOfVisit = DateTime.Parse("2024-03-20"),
                Description = "Wing trimming", Cost = 50.00m
            },
            new Visit
            {
                Id = 3, Animal = _animals.First(a => a.id == 3), DateOfVisit = DateTime.Parse("2024-01-12"),
                Description = "Health check", Cost = 200.00m
            },
        };
    }

    public ICollection<Animal> GetAllAnimals()
    {
        return _animals;
    }

    public bool AddAnimal(Animal animal)
    {
        _animals.Add(animal);
        return true;
    }

    public Animal? RemoveAnimal(int id)
    {
        throw new NotImplementedException();
    }

    public Animal? GetDetailsOfAnimal(int id)
    {
        return _animals.FirstOrDefault(ani => ani.id == id);
    }

    public Animal? UpdateAnimal(int id, Animal updatedAnimal)
    {
        throw new NotImplementedException();
    }

    public ICollection<Visit> GetVisitsByAnimalId(int animalID)
    {
        throw new NotImplementedException();
    }

    public bool AddVisit(Visit visit)
    {
        throw new NotImplementedException();
    }

    public Animal? FetchAnimal(int id)
    {
        return _animals.SingleOrDefault(a => a.id == id);
    }

    public Animal? DeleteAnimal(int id)
    {
        var animal = _animals.SingleOrDefault(a => a.id == id);
        if (animal == null)
        {
            return null;
        }

        _animals.Remove(animal);
        return animal;
    }

    public Animal? ModifyAnimal(int id, Animal modifiedAnimal)
    {
        var existingAnimal = _animals.SingleOrDefault(a => a.id == id);
        if (existingAnimal == null)
        {
            return null;
        }

        existingAnimal.name = modifiedAnimal.name;
        existingAnimal.category = modifiedAnimal.category;
        existingAnimal.Weight = modifiedAnimal.Weight;
        existingAnimal.hair_colour = modifiedAnimal.hair_colour;
        return existingAnimal;
    }

    public IEnumerable<Visit> RetrieveVisitsForAnimal(int animalId)
    {
        return _visits.Where(v => v.Animal.id == animalId).ToList();
    }

    public bool RecordVisit(Visit visit)
    {
        int highestId = _visits.Any() ? _visits.Max(v => v.Id) : 0;
        visit.Id = highestId + 1;
        _visits.Add(visit);
        return true;
    }
}