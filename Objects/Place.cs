using System.Collections.Generic;

namespace Places.Objects
{
  public class Place
  {
    private string _city;
    private string _picture;
    private int _population;
    private int _id;
    private static List<Place> _instances = new List<Place> {};

    public Place (string city, string picture, int population)
    {
      _city = city;
      _picture = picture;
      _population = population;
      _instances.Add(this);  // <-- this refers to the Place we just made
      _id = _instances.Count;
    }   // getters & setters
    public string GetCity()
    {
      return _city;
    }
    // public void SetCity(string city)
    // {                                   ///  <<< user sets thes
    //   _city = city;
    // }
    public string GetPicture()
    {
      return _picture;
    }
    // public void SetPicture(string picture)
    // {
    //   _picture = picture;
    // }
    public int GetPopulation()
    {
      return _population;
    }
    // public void SetPopulation(int population)
    // {
    //   _population = population;
    // }
    public int GetId()
    {
      return _id;
    }
    // Static methods
    public static List<Place> GetAllPlaces()
    {
      return _instances;
    }
    public static void ClearAllPlaces()
    {
      _instances.Clear();
    }
    // this method is run on a place to get it's id number
    public static Place Find(int searchId)
    {
      return _instances[searchId-1];
    }
  }
}
