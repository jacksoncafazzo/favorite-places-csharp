using Nancy;
using Places.Objects;
using Categories.Objects;
using System.Collections.Generic;
using System;

namespace Places
{
  public class HomeModule : NancyModule
  {
    public HomeModule()
    {

      Get["/"] = _ => View["index.cshtml", Category.GetAllTrips()]; // show the main page after sending it a list of place objects as Model
      Get["/categories"] = _ => {
        var allCategories = Category.GetAllTrips();
        return View["categories.cshtml", allCategories]; // show all categories
      };

      Post["/places"] = _ => {
        Dictionary<string, object> model = new Dictionary<string, object>();
        Category selectedCategory = Category.Find(Request.Form["category-id"]);
        List<Place> categoryPlaces = selectedCategory.GetPlaces();
        int populationInt = int.Parse(Request.Form["new-population"]);
        Place newPlace = new Place(Request.Form["new-place"], Request.Form["new-picture"], populationInt);
        categoryPlaces.Add(newPlace);
        model.Add("places", categoryPlaces); // add as key:value pairs
        model.Add("category", selectedCategory); //
        return View["category.cshtml", model];
      };

      Get["/categories/new"] = _ => {
        return View["new_trip_form.cshtml"];
      };

      Post["/categories"] = _ => {
        var newCategory = new Category(Request.Form["category-name"]);
        var allCategories = Category.GetAllTrips();
        return View["categories.cshtml", allCategories];
      };

      Get["/categories/{id}"] = parameters => {
        Dictionary<string, object> model = new Dictionary<string, object>();
        var selectedCategory = Category.Find(parameters.id);
        var categoryPlaces = selectedCategory.GetPlaces();
        model.Add("category", selectedCategory);
        model.Add("places", categoryPlaces);
        return View["category.cshtml", model];
      };

      Get["/categories/{id}/places/new"] = parameters => {
        Dictionary<string, object> model = new Dictionary<string, object>();
        Category selectedCategory = Category.Find(parameters.id);
        List<Place> allPlaces = selectedCategory.GetPlaces();
        model.Add("category", selectedCategory);
        model.Add("places", allPlaces);
        return View["add_new_trip.cshtml", model];
      };



      Get ["/clearPlaces/{id}"] = parameters => {
        Category selectedCategory = Category.Find(parameters.id);
        selectedCategory.ClearAllPlaces();
        return View["clearPlaces.cshtml", selectedCategory];
      };

      Get["/city/{id}"] = parameters => { // each city is a link with a number added on we can reference with GetPlaceById()
        Place place = Place.Find(parameters.id); // making a new place by
        return View["place.cshtml", place];
      };
      Post["/add_place"] = _ => {
        int populationInt = int.Parse(Request.Form["new-population"]);
        Place newPlace = new Place (Request.Form["new-place"], Request.Form["new-picture"], populationInt); // makes new place and puts it into the list of places
        return View["places.cshtml", Place.GetAllPlaces()]; //show the places page again
      };
      Get["/places_clear"] = _ => { // changed Post to Get, very important. We want to get the signal called "/places_clear" and do these things...
        Place.ClearAllPlaces();
        return View["place.cshtml"];
      };








      // Get["/"] = _ => View["add_new_task.cshtml"];
      // Get["/view_all_tasks"] = _ => {
      //   List<string> allTasks = Task.GetAll();
      //   return View["view_all_tasks.cshtml", allTasks];
      // };
      // Post["/tasks_cleared"] = _ => {
      //   Task.ClearAll();
      //   return View["tasks_cleared.cshtml"];
      // };
      // Post["/task_added"] = _ => {
      //   Task newTask = new Task (Request.Form["new-task"]);
      //   newTask.Save();
      //   return View["task_added.cshtml", newTask];
      // };
    }
  }
}
