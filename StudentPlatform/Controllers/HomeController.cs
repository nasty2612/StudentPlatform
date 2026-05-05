using Microsoft.AspNetCore.Mvc;
using StudentPlatform.Domain;

namespace StudentPlatform.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Contacts() 
        { 
            return View();
        }
    }
}
