using System;

namespace AirlinePlanner.Models
{
  public class City
  {
    private string _name;
    private int _id;

    public City(string name, int id = 0)
    {
      _name = name;
    }

    public string GetName(){return _name;}
    public void SetName(string newName){_name = newName;}
    public int GetId(){return _id;}

    
  }
}
