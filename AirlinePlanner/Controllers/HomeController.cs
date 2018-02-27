using Microsoft.AspNetCore.Mvc;
using AirlinePlanner.Models;
using System;
using System.Collections.Generic;

namespace AirlinePlanner.Controllers
{
  public class HomeController : Controller
  {

    [HttpGet("/")]
    public ActionResult Index()
    {
      List<City> allCities = City.GetAll();
      return View("Index", allCities);
    }
  }
}
