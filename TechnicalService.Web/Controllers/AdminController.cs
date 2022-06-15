using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TechnicalService.Core.Identity;
using TechnicalService.Web.ViewModels;
using TechnicalService.Web.ViewModels.Account;

namespace TechnicalService.Web.Controllers
{
	public class AdminController : Controller
	{

		private readonly UserManager<ApplicationUser> _userManager;

		public AdminController(UserManager<ApplicationUser> userManager)
        {
			_userManager = userManager;
        }

		public IActionResult AdminDashboard()
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


		