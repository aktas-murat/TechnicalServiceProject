using Microsoft.AspNetCore.Mvc;
using TechnicalService.Core.Entities;
using TechnicalService.Data.Data;

namespace TechnicalService.Web.Controllers
{
	public class AdminController : Controller
	{
        private readonly MyContext _context;
        public IActionResult AdminDashboard()
		{
			return View();
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
