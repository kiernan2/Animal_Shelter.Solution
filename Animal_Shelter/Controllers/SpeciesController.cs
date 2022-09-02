using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using Animal_Shelter.Models;

namespace Animal_Shelter.Controllers 
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