using Logic.Abstract_Service;
using Microsoft.AspNetCore.Mvc;

namespace MVC.Areas.Entities.Controllers
{
	[Area("Entities")]
	public class EmployeeMonthlyWagesController : Controller
	{
		private readonly IEmployeeMonthlyWagesService _service;

		public EmployeeMonthlyWagesController(IEmployeeMonthlyWagesService service)
        {
			_service = service;
		}
        public IActionResult Index()
		{
			return View();
		}
	}
}
