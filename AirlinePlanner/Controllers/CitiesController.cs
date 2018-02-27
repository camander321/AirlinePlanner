using Microsoft.AspNetCore.Mvc;
using AirlinePlanner.Models;
using System;
using System.Collections.Generic;

namespace AirlinePlanner.Controllers
{
  public class CitiesController : Controller
  {

    [HttpGet("/city/create")]
    public ActionResult Create()
    {
      List<City> allCities = City.GetAll();
      return View(allCities);
    }

    [HttpPost("/city/create")]
    public ActionResult Create()
    {
      City newCity = City(Request.Form["city"]);
      newCity.Save();
      List<City> allCities = City.GetAll();
      return View(allCities);
    }
  }
}
