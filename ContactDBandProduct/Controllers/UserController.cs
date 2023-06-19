using Microsoft.AspNetCore.Mvc;

namespace ContactDBandProduct.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
