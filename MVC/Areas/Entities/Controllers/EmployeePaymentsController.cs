using Logic.Abstract_Service;
using Microsoft.AspNetCore.Mvc;

namespace MVC.Areas.Entities.Controllers
{
    [Area("Entities")]
    public class EmployeePaymentsController : Controller
    {
        private readonly IEmployeePaymentsService _service;

        public EmployeePaymentsController(IEmployeePaymentsService service)
        {
            _service = service;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}