﻿using Entity.Entity;
using Logic.Abstract_Service;
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

        public SupplierController(ISupplierService service, ISupplierMapper supplierMapper)
        {
            _service = service;
            _supplierMapper = supplierMapper;
        }

        public IActionResult Index()
        {
            var suppliers = _service.GetSuppliers();
            var supplierDTOs = new List<SupplierDTO>();
            foreach (var supplier in suppliers)
            {
                if (supplier.State != EntityState.Deleted)
                {
                    supplierDTOs.Add(_supplierMapper.FromSupplier(supplier));
                }
            }
            return View(supplierDTOs);
        }

        public IActionResult CreateSupplier()
        {
            SupplierDTO supplierDTO = new();    
            return View(supplierDTO);
        }
        [HttpPost]
        public IActionResult CreateSupplier(SupplierDTO supplierDTO)
        {
            var supplier = _supplierMapper.ToSupplier(supplierDTO);
            var result = _service.CreateSupplier(supplier);
            TempData["Result"] = result;
            return RedirectToAction("Index");
        }

        public IActionResult UpdateSupplier(int id)
        {
            var supplier = _service.GetById(id);
            var supplierDTO = _supplierMapper.FromSupplier(supplier);
            return View(supplierDTO);
        }
        [HttpPost]
        public IActionResult UpdateSupplier(SupplierDTO supplierDTO)
        {
            var supplier = _supplierMapper.ToSupplier(supplierDTO);
            var result = _service.UpdateSupplier(supplier);
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
