using Entity.Entity;
using Logic.Abstract_Service;
using Logic.Concrete_Service;
using Microsoft.AspNetCore.Mvc;
using MVC.Areas.Entities.BaseControllers;
using MVC.Areas.Entities.Models.Alerts_And_Messages;
using MVC.Areas.Entities.Models.BaseModels;
using MVC.Areas.Entities.Models.MapperAbstract;
using MVC.Areas.Entities.Models.MapperConcrete;
using MVC.Areas.Entities.Models.ViewModels;
using System.Net;

namespace MVC.Areas.Entities.Controllers
{
    [Area("Entities")]
    public class SaleController : BaseDashboardController<SaleModel, ISaleService, SaleDto, ISaleMapper>
    {
        private readonly ISaleService _service;
        private readonly ISaleMapper _mapper;
        private readonly IDealerService _dealerService;
        private readonly IProductService _productService;

        public SaleController(ISaleService service,
                              ISaleMapper mapper,
                              IDealerService dealerService,
                              IProductService productService) : base (service, mapper)
        {
            _service = service;
            _mapper = mapper;
            _dealerService = dealerService;
            _productService = productService;
        }

        public override void PopulateData()
        {
            ViewBag.Dealers = _dealerService.GetAll().ToList();
            ViewBag.Products = _productService.GetAll().ToList();
        }

        [HttpPost]
        public override IActionResult Create(SaleDto dto)
        {
            if (Convert.ToDateTime(dto.StartDate) > Convert.ToDateTime(dto.EndDate))
            {
                ModelState.AddModelError("EndDate", "Bitiş Tarihi Başlangıç Tarihinden küçük olamaz!");
            }
            if (!ModelState.IsValid)
            {
                PopulateData();
                return View(dto);
            }
            var sale = _mapper.FromDto(dto);
            var result = _service.Create(sale, dto.Dealerids ?? new(), dto.Productids ?? new());
            
            if (result != HttpStatusCode.OK)
                ConfigureAlerts($"{GetModelName()} oluşturulurken bir hata oluştu!", SwalTypes.error);

            ConfigureAlerts($"{GetModelName()} başarıyla oluşturuldu!", SwalTypes.success);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public override IActionResult Update(SaleDto dto)
        {
            if (Convert.ToDateTime(dto.StartDate) > Convert.ToDateTime(dto.EndDate))
            {
                ModelState.AddModelError("EndDate", "Bitiş Tarihi Başlangıç Tarihinden küçük olamaz!");
            }
            if (!ModelState.IsValid)
            {
                PopulateData();
                return View(dto);
            }
            var sale = _mapper.FromDto(dto);
            var result = _service.Update(sale, dto.Dealerids ?? new(), dto.Productids ?? new());

            if (result != HttpStatusCode.OK)
                ConfigureAlerts($"{GetModelName()} güncellenirken bir hata oluştu!", SwalTypes.error);

            ConfigureAlerts($"{GetModelName()} başarıyla güncellendi!", SwalTypes.success);

            return RedirectToAction("Index");
        }
        
    }
}