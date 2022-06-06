using Microsoft.AspNetCore.Mvc;

namespace TechnicalService.Web.Controllers
{
    public class ServiceController : Controller
    {
        public IActionResult ServiceForm()
        {
            return View();
        }
    }
}
