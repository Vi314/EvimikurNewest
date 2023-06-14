using Entity.Entity;
using Entity.Identity;
using Logic.Abstract_Service;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC.Areas.Entities.BaseControllers;
using MVC.Areas.Entities.Models.MapperAbstract;
using MVC.Areas.Entities.Models.ViewModels;

namespace MVC.Areas.Entities.Controllers
{
    [Area("Entities")]
    public class SupplierController : BaseDashboardController<SupplierModel, ISupplierService, SupplierDto, ISupplierMapper>
    {
        private readonly ISupplierService _service;
        private readonly ISupplierMapper _mapper;
        private readonly UserManager<AppUser> _userManager;

        public SupplierController(ISupplierService service, ISupplierMapper mapper,UserManager<AppUser> userManager) : base (service, mapper)
        {
            _service = service;
            _mapper = mapper;
            _userManager = userManager;
        }

        public override void PopulateData()
        {
            ViewBag.Users = _userManager.Users.ToList() ?? new();
        }
        
    }
}