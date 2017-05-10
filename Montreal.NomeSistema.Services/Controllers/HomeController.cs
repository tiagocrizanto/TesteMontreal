using Montreal.NomeSistema.Modulo1.Application;
using System.Web.Mvc;

namespace Montreal.NomeSistema.Services.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }
    }
}