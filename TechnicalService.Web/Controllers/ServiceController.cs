﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TechnicalService.Core.Entities;
using TechnicalService.Core.ViewModels;
using TechnicalService.Data.Data;
using TechnicalService.Web.ViewModels;

namespace TechnicalService.Web.Controllersrepos
{
    public class ServiceController : Controller
    {
        //private readonly IRepository<ServiceDemand, int> _serviceDemandRepository;
        private readonly MyContext _context;
        private readonly IMapper _mapper;

        public ServiceController(IMapper mapper, MyContext context)
        {
            _mapper = mapper;
            _context = context;
        }


        //internal IRepository<ServiceDemand, int> ServiceDemandRepository => _serviceDemandRepository;

        public IActionResult ServiceForm()
        {
            return View();


        }

        [HttpPost]
        public async Task<IActionResult> ServiceForm(ServiceViewModel model)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError(string.Empty, "Bir hata oluştu");
                return View(model);
            }
            var demand = _mapper.Map<ServiceDemand>(model);
       
            await _context.ServiceDemands.AddAsync(demand);
            await _context.SaveChangesAsync();
            return View(model);

        }
    }
}

