using Logic.Abstract_Service;
using Microsoft.AspNetCore.Mvc;
using MVC.Areas.Entities.Models.MapperAbstract;
using MVC.Areas.Entities.Models.ViewModels;

namespace MVC.Areas.Entities.Controllers
{
	[Area("Entities")]
	public class SalesController : Controller
	{
		private readonly ISalesService _salesService;
		private readonly ISalesMapper _salesMapper;

		public SalesController(ISalesService salesService, ISalesMapper salesMapper)
		{
			_salesService = salesService;
			_salesMapper = salesMapper;
		}
		public IActionResult Index()
		{
			var sales = _salesService.GetAll();
			var salesDTOs = new List<SalesDTO>();
			foreach (var item in sales)
			{
				salesDTOs.Add(_salesMapper.FromSale(item));
			}
			return View(salesDTOs);
		}
	}
}
