﻿using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TechnicalServiceProject.Models;

namespace TechnicalServiceProject.Controllers
{
    public class HomeController : Controller
        /// deneme 1
    {
        private readonly ILogger<HomeController> _logger;
        //deneme2
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}