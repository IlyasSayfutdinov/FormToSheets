using Microsoft.AspNetCore.Mvc;

namespace WebApplicat.Controllers
{
    public class Controller1 : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
