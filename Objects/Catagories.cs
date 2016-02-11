using System.Collections.Generic;
using Places.Objects;

namespace Categories.Objects
{
  public class Category
  {
     // get list to display keys and values
    private static List<Category> _instances = new List<Category> {};
    private string _name;
    private int _id;
    private List<Place> _places;

    public Category(string categoryName)
    {
      _name = categoryName;
      _instances.Add(this);
      _id = _instances.Count;
      _places = new List<Place>{};
    }
    // getter and setter

    public string GetName()
    {
      return _name;
    }
    // we don't need to set the name, the user chooses what they are searching for
    public int GetId()
    {
      return _id;
    }
    // return list of places with that id
    public List<Place> GetPlaces()
    {
      return _places;
    }

    //add place to category list

    public void AddPlace(Place place)
    {
      _places.Add(place);
    }

    public static List<Category> GetAllTrips()
    {
      return _instances;
    }
    public static void ClearCategories()
    {
      _instances.Clear();
    }

    public void ClearAllPlaces()
    {
      _places.Clear();
    }
    // this method shows the dictionary key (the category name) that matches the id
    public static Category Find(int searchId)
    {
      return _instances[searchId-1];
    }
  }
}
