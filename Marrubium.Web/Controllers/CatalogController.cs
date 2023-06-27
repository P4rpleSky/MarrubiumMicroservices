using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Marrubium.Web.Controllers
{
    public class CatalogController : Controller
    {
        public ActionResult Main()
        {
            return View();
        }
    }
}
