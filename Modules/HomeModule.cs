using System.Collections.Generic;
using Nancy;
using Nancy.ViewEngines.Razor;

namespace GroupProject
{
  public class HomeModule : NancyModule
  {
    public HomeModule()
    {
      Get["/"] = _ => //To index.cshtml
      {
        List<Organization> allOrganizations = Organization.GetAll();  //Instantiate a new object of all of the organizations.
        return View["index.cshtml", allOrganizations];
      };
      Get["/about"] = _ =>
      {
        return View["about.cshtml"];
      };
      Get["/contact"] = _ =>
      {
        return View["contact.cshtml"];
      };

      Get["/sign_in"] = _ => //localhost:5004/user/new In the case that this is a new user bring them to this page.
      {
        return View["sign_in.cshtml"]; //Show the html.
      };

      Post["/sign_in"] = _ => //Collect user credentials. //Where the user goes
      {
        string username = Request.Form["username"]; //Request the form, look for matching strings.
        string password = Request.Form["password"];

        User loginUser = User.UserLookup(username);
        if(password == loginUser.GetPassword())
        {
          return View["profile.cshtml", loginUser]; //If the username matches and the password matches its user, show them their profile.
        }
        else
        {
          return View["sign_in.cshtml"]; //Otherwise refresh the page.
        }
      };

      Post["/user/new"] = _ => //Create the profile page of the user based off these queries.
      {
        User newUser = new User(Request.Form["username"], Request.Form["password"], Request.Form["name"], Request.Form["email"], "");
        newUser.Save();
        return View["profile.cshtml", newUser]; //Returns a profile page for this user:D
      };


      Post["/organization/info/{id}"] = parameters =>  //If user clicks donate, return the donate form.
      {
        Dictionary<string, object> model = new Dictionary<string, object>();
        Organization selectedOrganization = Organization.Find(parameters.id);
        List<Organization> allOrganizations = Organization.GetAll();
        model.Add("allOrganizations", allOrganizations);
        model.Add("selectedOrganization", selectedOrganization);
        return View["cause_screen.cshtml", model];
      };

      //When a user clicks donate, they expect to see a form in which they can add $$ to the specified organization.
      // Post["/donate/organization"] = _ =>
      // {
      //   Organization donate =  new Organization(Request.Form["organization-name"]);
      //   donate.Save();
      //   return View["thank_you.cshtml"]; //After the form is submitted, provide a thank you message, "thanks for donating to @Cause.GetName()!"
      // };

      //  Post["/organization/info"] = _ =>
      //    {
      //    string button = Request.Form["button"];
      //    return View["index.cshtml", button];
      //  };
    }
  }
}
