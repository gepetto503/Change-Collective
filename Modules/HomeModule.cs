using System.Collections.Generic;
using Nancy;
using Nancy.ViewEngines.Razor;

namespace GroupProject
{
  public class HomeModule : NancyModule
  {
    public HomeModule()
    {
      Get["/"] = _=>
      {
        return View["index.cshtml"];
      };
    }
  }
}
