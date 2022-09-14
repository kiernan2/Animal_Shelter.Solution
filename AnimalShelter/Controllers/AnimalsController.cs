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

    [HttpPost]
    public ActionResult Index(string species)
    {
      
      return RedirectToAction("Search");
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

    // public ActionResult Reset()
    // {
    //   return RedirectToAction("Reset");
    // }

    public ActionResult Delete(int id)
    {
      Animal thisAnimal = _db.Animals.FirstOrDefault(animal => animal.AnimalId == id);
      return RedirectToAction("Delete");
    }

    [HttpGet]
    public ActionResult Reset()
    {
      return View();
    }

    [HttpGet]
    public ActionResult Delete()
    {
      return View();
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      Animal thisAnimal = _db.Animals.FirstOrDefault(animal => animal.AnimalId == id);
      _db.Animals.Remove(thisAnimal);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    [HttpPost, ActionName("Reset")]
    public ActionResult ResetConfirmed()
    {
      _db.Animals.RemoveRange(_db.Animals);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    [HttpPost, ActionName("Search")]
    public ActionResult SearchSpecies(string species)
    {
      List<Animal> SearchList = _db.Animals.Where(Animal => Animal.Species == species).ToList();
      return View(SearchList);
    }
  }
}