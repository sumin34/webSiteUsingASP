using ContactDBandProduct.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ContactDBandProduct.Controllers
{
    public class UserController : Controller
    {
        [Authorize(Roles ="User")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string id, string pw)
        {
            return View();
        }

        [HttpGet]
        public IActionResult Signup()
        {
            return View();
        }



        [HttpPost]
        public IActionResult Signup(User userModel)
        {

            return View();
        }
    }
}
