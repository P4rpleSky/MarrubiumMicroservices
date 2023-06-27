using Microsoft.AspNetCore.Mvc;

namespace Marrubium.Web.Controllers;

public class HomeController : Controller
{
    public ActionResult Main()
    {
        return View();
    }
    
    public ActionResult About()
    {
        return View();
    }
    
    public ActionResult Delivery()
    {
        return View();
    }
    
    public ActionResult Contacts()
    {
        return View();
    }
}