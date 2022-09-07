using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using AnimalShelter.Models;

namespace AnimalShelter.Controllers 
{
  public class SpeciesController : Controller
  {
    [HttpGet("/species")]
    public ActionResult Index()
    {
      List<Species> allSpecies = Species.GetAll();
      return View();
    }

    // [HttpGet("/species")]
    // public ActionResult New()
    // {
      
    // }
  }

}