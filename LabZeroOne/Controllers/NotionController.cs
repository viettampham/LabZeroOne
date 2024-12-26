using Microsoft.AspNetCore.Mvc;

namespace LabZeroOne.Controllers
{
    public class NotionController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
