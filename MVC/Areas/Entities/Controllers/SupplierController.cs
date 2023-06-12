using Entity.Identity;
using Logic.Abstract_Service;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC.Areas.Entities.Models.MapperAbstract;
using MVC.Areas.Entities.Models.ViewModels;

namespace MVC.Areas.Entities.Controllers
{
    [Area("Entities")]
    public class SupplierController : Controller
    {
        private readonly ISupplierService _service;
        private readonly ISupplierMapper _supplierMapper;
        private readonly UserManager<AppUser> _userManager;

        public SupplierController(ISupplierService service, ISupplierMapper supplierMapper,UserManager<AppUser> userManager)
        {
            _service = service;
            _supplierMapper = supplierMapper;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            var suppliers = _service.GetSuppliers();
            var supplierDTOs = new List<SupplierDTO>();
            foreach (var supplier in suppliers)
            {
                if (supplier.State != EntityState.Deleted)
                {
                    supplierDTOs.Add(_supplierMapper.FromEntity(supplier));
                }
            }
            return View(supplierDTOs);
        }

        public IActionResult CreateSupplier()
        {
            ViewBag.Users = _userManager.Users.ToList() ?? new();
            return View(new SupplierDTO());
        }

        [HttpPost]
        public IActionResult CreateSupplier(SupplierDTO supplierDTO)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Users = _userManager.Users.ToList() ?? new();
                return View(supplierDTO);
            }
            var supplier = _supplierMapper.FromDto(supplierDTO);
            var result = _service.CreateOne(supplier);
            TempData["Result"] = result;
            return RedirectToAction("Index");
        }

        public IActionResult UpdateSupplier(int id)
        {
            ViewBag.Users = _userManager.Users.ToList() ?? new();
            var supplier = _service.GetById(id);
            var supplierDTO = _supplierMapper.FromEntity(supplier);
            return View(supplierDTO);
        }

        [HttpPost]
        public IActionResult UpdateSupplier(SupplierDTO supplierDTO)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Users = _userManager.Users.ToList() ?? new();
                return View(supplierDTO);
            }
            var supplier = _supplierMapper.FromDto(supplierDTO);
            var result = _service.UpdateOne(supplier);
            TempData["Result"] = result;
            return RedirectToAction("Index");
        }

        public IActionResult DeleteSupplier(int id)
        {
            var result = _service.DeleteSupplier(id);
            TempData["Result"] = result;
            return RedirectToAction("Index");
        }
    }
}