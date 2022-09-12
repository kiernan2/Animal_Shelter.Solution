using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using AnimalShelter.Models;

namespace AnimalShelter.Controllers
{
  public class AnimalsController : Controller
  {
    private readonly AnimalShelterContext _db;

    public AnimalsController(AnimalShelterContext db)
    {
      _db = db;
    }

    // [HttpGet("/Animals")]
    public ActionResult Index()
    {
      List<Animal> animal = _db.Animals.ToList();
      return View(animal);
    }

    public ActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Create(Animal animal)
    {
      _db.Animals.Add(animal);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      Animal thisAnimal = _db.Animals.FirstOrDefault(animal => animal.AnimalId == id);
      return View(thisAnimal);
    }

    public ActionResult Delete(int id)
    {
      Animal thisAnimal = _db.Animals.FirstOrDefault(animal => animal.AnimalId == id);
      return RedirectToAction("Reset");
    }

    [HttpGet]
    public ActionResult Reset()
    {
      return View();
    }

    [HttpPost, ActionName("Reset")]
    public ActionResult DeleteConfirmed()
    {
      _db.Animals.RemoveRange(_db.Animals);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}