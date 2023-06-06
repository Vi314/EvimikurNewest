using Logic.Abstract_Service;
using Microsoft.AspNetCore.Mvc;
using MVC.Areas.Entities.Models.MapperAbstract;
using MVC.Areas.Entities.Models.ViewModels;

namespace MVC.Areas.Entities.Controllers
{
    [Area("Entities")]
    public class SaleController : Controller
    {
        private readonly ISaleService _saleService;
        private readonly ISaleMapper _saleMapper;
        private readonly IDealerService _dealerService;
        private readonly IProductService _productService;

        public SaleController(ISaleService saleService,
                              ISaleMapper saleMapper,
                              IDealerService dealerService,
                              IProductService productService)
        {
            _saleService = saleService;
            _saleMapper = saleMapper;
            _dealerService = dealerService;
            _productService = productService;
        }

        public IActionResult Index()
        {
            var sales = _saleService.GetAll().ToList();
            var saleDTOs = new List<SaleDTO>();
            foreach (var item in sales)
            {
                saleDTOs.Add(_saleMapper.FromEntity(item));
            }
            return View(saleDTOs);
        }

        public IActionResult Create()
        {
            ViewBag.Dealers = _dealerService.GetDealers().ToList();
            ViewBag.Products = _productService.GetProducts().ToList();
            return View(new SaleDTO());
        }

        [HttpPost]
        public IActionResult Create(SaleDTO saleDTO)
        {
            if (Convert.ToDateTime(saleDTO.StartDate) > Convert.ToDateTime(saleDTO.EndDate))
            {
                ModelState.AddModelError("EndDate", "Bitiş Tarihi Başlangıç Tarihinden küçük olamaz!");
            }
            if (!ModelState.IsValid)
            {
                ViewBag.Dealers = _dealerService.GetDealers().ToList();
                ViewBag.Products = _productService.GetProducts().ToList();
                return View(saleDTO);
            }
            var sale = _saleMapper.FromDto(saleDTO);
            TempData["Result"] = _saleService.CreateOne(sale, saleDTO.Dealerids, saleDTO.Productids);
            return RedirectToAction("Index");
        }

        public IActionResult Update(int id)
        {
            ViewBag.Dealers = _dealerService.GetDealers().ToList();
            ViewBag.Products = _productService.GetProducts().ToList();
            var sale = _saleService.GetById(id);
            var saleDto = _saleMapper.FromEntity(sale);
            return View(saleDto);
        }

        [HttpPost]
        public IActionResult Update(SaleDTO saleDTO)
        {
            if (Convert.ToDateTime(saleDTO.StartDate) > Convert.ToDateTime(saleDTO.EndDate))
            {
                ModelState.AddModelError("EndDate", "Bitiş Tarihi Başlangıç Tarihinden küçük olamaz!");
            }
            if (!ModelState.IsValid)
            {
                ViewBag.Dealers = _dealerService.GetDealers().ToList();
                ViewBag.Products = _productService.GetProducts().ToList();
                return View(saleDTO);
            }
            var sale = _saleMapper.FromDto(saleDTO);
            TempData["Result"] = _saleService.UpdateOne(sale, saleDTO.Dealerids, saleDTO.Productids);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            TempData["Result"] = _saleService.DeleteOne(id);
            return RedirectToAction("Index");
        }
    }
}