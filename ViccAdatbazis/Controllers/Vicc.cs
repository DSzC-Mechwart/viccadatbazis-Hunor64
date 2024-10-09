using Microsoft.AspNetCore.Mvc;

namespace ViccAdatbazis.Controllers
{
    public class Vicc : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
