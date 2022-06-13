using Microsoft.AspNetCore.Mvc;

namespace TechnicalService.Web.Controllers
{
	public class AdminController : Controller
	{
		public IActionResult AdminDashboard()
		{
			return View();
		}
	}
}
