using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using TechnicalService.Core.Entities;
using TechnicalService.Core.Identity;
using TechnicalService.Core.ViewModels;
using TechnicalService.Data.Data;
using TechnicalService.Web.Extensions;
using TechnicalService.Web.ViewModels;

namespace TechnicalService.Web.Controllersrepos
{
    public class ServiceController : Controller
    {
        //private readonly IRepository<ServiceDemand, int> _serviceDemandRepository;
        private readonly MyContext _context;
        private readonly IMapper _mapper;
        private readonly UserManager<ApplicationUser> _userManager;

        public ServiceController(IMapper mapper, MyContext context, UserManager<ApplicationUser> userManager)
        {
            _mapper = mapper;
            _context = context;
            _userManager = userManager;
        }


        //internal IRepository<ServiceDemand, int> ServiceDemandRepository => _serviceDemandRepository;

        [Authorize]
        public IActionResult ServiceForm()
        {
            return View();


        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> ServiceForm(ServiceViewModel model)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError(string.Empty, "Bir hata oluştu");
                return View(model);
            }
            var demand = _mapper.Map<ServiceDemand>(model);

            demand.UserId = HttpContext.GetUserId();

            await _context.ServiceDemands.AddAsync(demand);
            await _context.SaveChangesAsync();

            TempData["Status"] = "Success";
            return RedirectToAction("ServiceDemands", "Service");
        }

        [Authorize]
        public IActionResult ServiceDemands()
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

