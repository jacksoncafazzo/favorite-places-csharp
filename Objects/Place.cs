using System.Collections.Generic;

namespace Places.Objects
{
  public class Place
  {
    private string _city;
    private string _picture;
    private int _population;
    private int _id;
    private static List<Place> _places = new List<Place> {};

    public Place (string city, string picture, int population)
    {
      _city = city;
      _picture = picture;
      _population = population;
      _places.Add(this);  // <-- this refers to the Place we just made
      _id = _places.Count;
    }   // getters & setters
    public string GetCity()
    {
      return _city;
    }
    public void SetCity(string city)
    {
      _city = city;
    }
    public string GetPicture()
    {
      return _picture;
    }
    public void SetPicture(string picture)
    {
      _picture = picture;
    }
    public int GetPopulation()
    {
      return _population;
    }
    public void SetPopulation(int population)
    {
      _population = population;
    }
    public int GetId()
    {
      return _id;
    }
    // Static methods
    public static List<Place> GetAll()
    {
      return _places;
    }
    public static void ClearAll()
    {
      _places = new List<Place>() {};
    }
    // this method is run on a place (like a prototype maybe?) to get it's id number
    public static Place Find(int id)
    {
      return _places[id-1];
    }
  }
}
