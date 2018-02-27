using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace AirlinePlanner.Models
{
  public class Flight
  {
    private DateTime _time;
    private string _status;
    private int _id;

    public Flight(DateTime time, string status, int id = 0)
    {
      _time = time;
      _status = status;
      _id = id;
    }

    public DateTime GetTime(){return _time;}
    public void SetTime(DateTime newTime){_time = newTime;}
    public string GetStatus(){return _status;}
    public void SetStatus(string newStatus){_status = newStatus;}
    public int GetId(){return _id;}

    public override bool Equals(System.Object otherFlight)
    {
      if (!(otherFlight is Flight))
      {
        return false;
      }
      else
      {
        Flight newFlight = (Flight) otherFlight;
        return _id == newFlight._id && _time == newFlight._time && _status == newFlight._status;
      }
    }
    public override int GetHashCode()
    {
      return _id.GetHashCode();
    }

    public void Save()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();

      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"INSERT INTO flights (time, status) VALUES (@FlightTime, @FlightStatus);";

      cmd.Parameters.Add(new MySqlParameter("@FlightTime", _time));

      cmd.Parameters.Add(new MySqlParameter("@FlightStatus", _status));

      cmd.ExecuteNonQuery();
      _id = (int) cmd.LastInsertedId;

      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }

    public static List<Flight> GetAll()
    {
      List<Flight> allFlights = new List<Flight> {};
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM flights;";
      var rdr = cmd.ExecuteReader() as MySqlDataReader;
      while(rdr.Read())
      {
        int FlightId = rdr.GetInt32(0);
        DateTime FlightTime = rdr.GetDateTime(1);
        string FlightStatus = rdr.GetString(2);
        Flight newFlight = new Flight(FlightTime, FlightStatus, FlightId);
        allFlights.Add(newFlight);
        Console.WriteLine(FlightId + " " + FlightTime + " " + FlightStatus);
      }
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return allFlights;
    }

    public static void DeleteAll()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();

      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"TRUNCATE TABLE flights;";

      cmd.ExecuteNonQuery();

      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }

    public static Flight Find(int id)
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM flights WHERE id = @FlightId;";
      cmd.Parameters.Add(new MySqlParameter("@FlightId", id));
      var rdr = cmd.ExecuteReader() as MySqlDataReader;

      int flightId = 0;
      DateTime flightTime = DateTime.Today;
      string flightStatus = "";
      if(rdr.Read())
      {
        flightId = rdr.GetInt32(0);
        flightTime = rdr.GetDateTime(1);
        flightStatus = rdr.GetString(2);
      }
      Flight newFlight = new Flight(flightTime, flightStatus, flightId);
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return newFlight;
    }

    public static void Delete(int id)
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"DELETE FROM flights WHERE id = @FlightId;";

      cmd.Parameters.Add(new MySqlParameter("@FlightId", id));
      cmd.ExecuteNonQuery();
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }

  }
}
