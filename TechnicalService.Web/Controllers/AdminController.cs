<<<<<<< HEAD
﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TechnicalService.Core.Identity;
using TechnicalService.Web.ViewModels;
using TechnicalService.Web.ViewModels.Account;
=======
﻿using Microsoft.AspNetCore.Mvc;
using TechnicalService.Core.Entities;
using TechnicalService.Data.Data;
>>>>>>> 51491bd9e436675244b862fe87347caced6742ef

namespace TechnicalService.Web.Controllers
{
	public class AdminController : Controller
	{
<<<<<<< HEAD

		private readonly UserManager<ApplicationUser> _userManager;

		public AdminController(UserManager<ApplicationUser> userManager)
        {
			_userManager = userManager;
        }

		public IActionResult AdminDashboard()
=======
        private readonly MyContext _context;
        public IActionResult AdminDashboard()
>>>>>>> 51491bd9e436675244b862fe87347caced6742ef
		{
			return View();
		}
		public IActionResult AdminProductPage()
		{
			return View();
		}
		[Authorize(Roles ="Admin")]
        public async Task<IActionResult> EditUserRole()
		{
		

		   var users = _userManager.Users.ToList();
			var model = new List<UserRoleChangeViewModel>();

            foreach (ApplicationUser item in users)
            {
				var thisViewModel = new UserRoleChangeViewModel();
				thisViewModel.Name = item.Name;
				thisViewModel.SurName = item.Surname;
				thisViewModel.UserName = item.UserName;
				thisViewModel.Role = await _userManager.GetRolesAsync(item);
				model.Add(thisViewModel);
            }
			return View(model);

		}
	}

}


		

		public IActionResult AdminServiceDemands()
        {
            var model = from sd in _context.ServiceDemands
                        join customer in _context.Users on sd.UserId equals customer.Id
                        select (new ServiceDemand
                        {
                            UserId = sd.UserId,
                            Address = sd.Address,
                            BuildingNo = sd.BuildingNo,
                            CreatedAt = sd.CreatedAt,
                            DoorNo = sd.DoorNo,
                            Email = sd.Email,
                            Id = sd.Id,
                            Message = sd.Message,
                            Phone = sd.Phone,
                            TechnicianId = sd.TechnicianId
                            //StatusId = sd.StatusId


                        });

            //  model.ToList().ForEach(x =>
            //{
            //    var technician = _userManager.FindByIdAsync(x.TechnicianId);
            //      //var customer =  _userManager.FindByIdAsync(x.UserId);
            //  });

            return View(model.ToList());
        }
    }
}
