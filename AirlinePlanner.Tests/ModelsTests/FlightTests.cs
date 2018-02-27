using Microsoft.VisualStudio.TestTools.UnitTesting;
using AirlinePlanner.Models;
using System;
using System.Collections.Generic;

namespace AirlinePlanner.Models.Tests
{
  [TestClass]
  public class FlightTest : IDisposable
 {
   public FlightTest()
   {
     DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=airlines;";
     City.DeleteAll();
   }

   public void Dispose()
   {
     Flight.DeleteAll();
   }

   [TestMethod]
   public void GetAll_GetListOfSavedFlights_ListCity()
   {
     DateTime flightTime = DateTime.Parse("3/13/18");
     Flight testFlight1 = new Flight(flightTime, "On Time");
     testFlight1.Save();
     List<Flight> newFlightList = new List<Flight>{testFlight1};

     Assert.AreEqual(newFlightList.Count, Flight.GetAll().Count);
     CollectionAssert.AreEqual(newFlightList, Flight.GetAll());
   }

   [TestMethod]
   public void Find_GetFlightWithId_City()
   {
     DateTime flightTime = DateTime.Parse("3/13/18");
     Flight testFlight1 = new Flight(flightTime, "On Time");
     testFlight1.Save();

     Assert.AreEqual(testFlight1, Flight.Find(testFlight1.GetId()));
   }

   [TestMethod]
   public void Delete_RemoveCityFromId_Void()
   {
     DateTime flightTime = DateTime.Parse("3/13/18");
     Flight testFlight1 = new Flight(flightTime, "On Time");
     testFlight1.Save();

     Flight testFlight2 = new Flight(flightTime, "Delayed");
     testFlight2.Save();

     Flight testFlight3 = new Flight(flightTime, "Cancelled");
     testFlight3.Save();

     Flight.Delete(testFlight2.GetId());

     CollectionAssert.AreEqual(new List<Flight>{testFlight1, testFlight3}, Flight.GetAll());
   }
  }
}
