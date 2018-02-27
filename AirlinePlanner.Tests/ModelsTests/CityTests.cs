using Microsoft.VisualStudio.TestTools.UnitTesting;
using AirlinePlanner.Models;
using System;
using System.Collections.Generic;

namespace AirlinePlanner.Models.Tests
{
  [TestClass]
  public class CityTest : IDisposable
 {
    public CityTest()
    {
      DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=airlines;";
      City.DeleteAll();
    }

    public void Dispose()
    {
      City.DeleteAll();
    }

    [TestMethod]
    public void GetAll_GetListOfSavedCities_ListCity()
    {
      City testCity1 = new City("portland");
      testCity1.Save();

      CollectionAssert.AreEqual(new List<City>{testCity1}, City.GetAll());
    }

    [TestMethod]
    public void Find_GetCityWithId_City()
    {
      City testCity1 = new City("portland");
      testCity1.Save();

      Assert.AreEqual(testCity1, City.Find(testCity1.GetId()));
    }

    [TestMethod]
    public void Delete_RemoveCityFromId_Void()
    {
      City testCity1 = new City("portland");
      testCity1.Save();

      City testCity2 = new City("seattle");
      testCity2.Save();

      City testCity3 = new City("miami");
      testCity3.Save();

      City.Delete(testCity2.GetId());

      CollectionAssert.AreEqual(new List<City>{testCity1, testCity3}, City.GetAll());
    }
  }
}
