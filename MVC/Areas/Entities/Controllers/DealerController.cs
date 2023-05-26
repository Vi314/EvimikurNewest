	
using Entity.Entity;
using Logic.Abstract_Service;
using Microsoft.AspNetCore.Mvc;
using MVC.Areas.Entities.Models.MapperAbstract;
using MVC.Areas.Entities.Models.ViewModels;

namespace MVC.Areas.Entities.Controllers
{
    [Area("Entities")]
    public class DealerController : Controller
    {
	    private readonly IDealerService _service;
		private readonly IDealerMapper _dealerMapper;

		public DealerController(IDealerService service,IDealerMapper dealerMapper)
	    {
		    _service = service;
			_dealerMapper = dealerMapper;
		}
		public IActionResult CreateDealer()
		{
			DealerDTO dealerDTO = new();
			return View(dealerDTO);
		}
		[HttpPost]
		public IActionResult CreateDealer(DealerDTO dealerDTO)
	    {
            if (!ModelState.IsValid)
            {
                return View(dealerDTO);
            }
            var dealer = _dealerMapper.FromDto(dealerDTO);
			var result = _service.CreateOne(dealer);
			ViewData["Result"] = result;
		    return RedirectToAction("Index");
	    }
	    public IActionResult Index()
	    {
			var dealers = _service.GetDealers();
			//TempData["Result"] = (dealers.ToList())[0].Sales[0];
			var dealerDTOs = new List<DealerDTO>();
			foreach (var item in dealers)
			{
				if (item.State != Microsoft.EntityFrameworkCore.EntityState.Deleted)
				{
					dealerDTOs.Add(_dealerMapper.FromEntity(item));
				}
			}
		    return View(dealerDTOs);
	    }
		public IActionResult UpdateDealer(int id)
		{
			var dealer = _service.GetById(id);
			var dealerDTO = _dealerMapper.FromEntity(dealer);
			return View(dealerDTO);
		}
		[HttpPost]
		public IActionResult UpdateDealer(DealerDTO dealerDTO)
	    {
            if (!ModelState.IsValid)
            {
                return View(dealerDTO);
            }
            var dealer = _dealerMapper.FromDto(dealerDTO);
			var result = _service.UpdateOne(dealer);
			ViewData["Result"] = result;
			return RedirectToAction("Index");
	    }
	    public IActionResult DeleteDealer(int id)
	    {
			var result = _service.DeleteDealer(id);
			ViewData["Result"] = result;
			return RedirectToAction("Index");
	    }
	}
}
