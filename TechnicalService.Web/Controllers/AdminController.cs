﻿using Microsoft.AspNetCore.Mvc;

namespace TechnicalService.Web.Controllers
{
	public class AdminController : Controller
	{
		public IActionResult AdminDashboard()
		{
			return View();
		}
		public IActionResult AdminProductPage()
		{
			return View();
		}

		public IActionResult EditUserRole()
		{
			return View();
		}
	}

}


		