using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Animal_Shelter.Models;

namespace Animal_Shelter.Controllers
{
  public class AnimalController : Controller
  {
    private readonly AnimalShelterContext _db;

    public AnimalController(AnimalShelterContext db)
    {
      _db = _db;
    }

    public ActionResult Index()
    {
      List<Animal> animal = _db.Animal.ToList();
      return View(animal);
    }

    public ActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Create(Animal animal)
    {
      _db.Animal.Add(animal);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      Animal thisAnimal = _db.Animal.FirstOrDefault(animal => animal.AnimalId == id);
      return View(thisAnimal);
    }
  }
}