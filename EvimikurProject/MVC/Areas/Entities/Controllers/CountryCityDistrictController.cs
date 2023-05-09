using Microsoft.AspNetCore.Mvc;

namespace MVC.Areas.Entities.Controllers
{
	[Area("Entities")]
	public class CountryCityDistrictController : Controller
	{
		public IActionResult CreateCountry()
		{
			return View();
		}
		public IActionResult ReadCountry()
		{
			return View();
		}
		public IActionResult UpdateCountry()
		{
			return View();
		}
		public IActionResult DeleteCountry()
		{
			return View();
		}
		//////////////////////////////////////
		public IActionResult CreateCity()
		{
			return View();
		}
		public IActionResult ReadCity()
		{
			return View();
		}
		public IActionResult UpdateCity()
		{
			return View();
		}
		public IActionResult DeleteCity()
		{
			return View();
		}
		////////////////////////////////////////
		public IActionResult Create()
		{
			return View();
		}
		public IActionResult Read()
		{
			return View();
		}
		public IActionResult Update()
		{
			return View();
		}
		public IActionResult Delete()
		{
			return View();
		}

	}
}
