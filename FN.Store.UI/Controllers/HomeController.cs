using Microsoft.AspNetCore.Mvc;

namespace FN.Store.UI.Controllers
{
    public class HomeController : Controller
    {
        public ViewResult Index()
        {
            return View();
        }

        public ViewResult Sobre()
        {
            return View();
        }
    }
}