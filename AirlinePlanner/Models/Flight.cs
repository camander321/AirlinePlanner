using System;

namespace AirlinePlanner.Models
{
  public class Flight
  {
    private DateTime _time;
    private enum _status;
    private int _id;

    public Flight(DateTime time, enum status, int id = 0)
    {
      _time = time;
      _status = status;
    }

    public string GetTime(){return _time;}
    public void SetTime(DateTime newTime){_time = newTime;}
    public string GetStatus(){return _status;}
    public void SetStatus(DateTime newStatus){_status = newStatus;}
    public int GetId(){return _id;}

  }
}
