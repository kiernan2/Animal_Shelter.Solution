using Microsoft.AspNetCore.Mvc;
using Animal_Shelter.Models;
using System.Collections.Generic;

namespace Animal_Shelter.Controllers
{
  [HttpGet("/")]
  public ActionResult Index()
  {
    return View();
  }
}