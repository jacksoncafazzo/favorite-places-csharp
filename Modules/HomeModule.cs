using Nancy;
using Places.Objects;
using System.Collections.Generic;
using System;

namespace Places
{
  public class HomeModule : NancyModule
  {
    public HomeModule()
    {

      Get["/"] = _ => View["places.cshtml", Place.GetAll()]; // show the main page after sending it a list of place objects as Model

      Get["/city/{id}"] = parameters => { // each city is a link with a number added on we can reference with GetPlaceById()
        Place place = Place.Find(parameters.id); // making a new place by
        return View["place.cshtml", place];
      };
      Post["/add_place"] = _ => {
        int intPopulation = int.Parse(Request.Form["new-population"]);
        Place newPlace = new Place (Request.Form["new-place"], Request.Form["new-picture"], intPopulation); // makes new place and puts it into the list of places
        return View["places.cshtml", Place.GetAll()]; //show the main page again
      };
      Get["/places_clear"] = _ => { // changed Post to Get, very important. We want to get the signal called "/places_clear" and do these things...
        Place.ClearAll();
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
