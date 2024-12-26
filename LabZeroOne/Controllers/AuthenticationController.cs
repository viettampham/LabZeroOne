using Microsoft.AspNetCore.Mvc;

namespace LabZeroOne.Controllers
{
    public class AuthenticationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
