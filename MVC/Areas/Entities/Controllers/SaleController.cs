using Logic.Abstract_Service;
using Microsoft.AspNetCore.Mvc;
using MVC.Areas.Entities.Models.ViewModels;

namespace MVC.Areas.Entities.Controllers
{
    [Area("Entities")]
    public class SaleController : Controller
    {
        private readonly ISaleService _saleService;

        public SaleController(ISaleService saleService)
        {
            _saleService = saleService;
        }
        
        public IActionResult Index()
        {
            var saleDTOs = new List<SaleDTO>();
            return View(saleDTOs);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(SaleDTO saleDTO)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            return RedirectToAction("Index");
        }
        public IActionResult Update(int id)
        {
            return View();
        }
        [HttpPost]
        public IActionResult Update(SaleDTO saleDTO)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            TempData["Result"] = _saleService.DeleteOne(id);
            return RedirectToAction("Index");
        }



    }
}
