using Microsoft.AspNetCore.Mvc;

namespace ViccAdatbazis.Controllers
{
    public class ViccController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
