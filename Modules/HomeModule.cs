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

      Get["/sign_in"] = _ =>
      {
        return View["sign_in.cshtml"];
      };

      Post["/sign_in"] = _ =>
      {
        string username = Request.Form["username"];
        string password = Request.Form["password"];

        User loginUser = User.UserLookup(username);
        if(password == loginUser.GetPassword())
        {
          return View["profile.cshtml", loginUser];
        }
        else
        {
          return View["sign_in.cshtml"];
        }
      };

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
