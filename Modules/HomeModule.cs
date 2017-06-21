using System.Collections.Generic;
using Nancy;
using Nancy.ViewEngines.Razor;

namespace GroupProject
{
  public class HomeModule : NancyModule
  {
    public HomeModule()
    {
      Get["/"] = _ =>
      {
        List<Organization> allOrganizations = Organization.GetAll();
        return View["index.cshtml", allOrganizations];
      };

      // Get["/sign_in"] = _ =>
      // {
      //   List<User> user = User.GetId();
      //   return View["sign_in.cshtml"];
      // };
      Post["/user/new"] = _ =>
      {
        User newUser = new User(Request.Form["username"], Request.Form["password"], Request.Form["name"], Request.Form["email"], "");
        newUser.Save();
        // User newAccount = newUser.GetId();
        return View["profile.cshtml", newUser];
      };
    }
  }
}
