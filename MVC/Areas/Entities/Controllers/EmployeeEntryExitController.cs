using Logic.Abstract_Service;
using Microsoft.AspNetCore.Mvc;
using MVC.Areas.Entities.Models.MapperAbstract;
using MVC.Areas.Entities.Models.ViewModels;

namespace MVC.Areas.Entities.Controllers;

[Area("Entities")]
public class EmployeeEntryExitController : Controller
{
	private readonly IEmployeeEntryExitService _service;
	private readonly IEmployeeEntryExitMapper _mapper;
	private readonly IEmployeeService _employeeService;

	public EmployeeEntryExitController(IEmployeeEntryExitService service, IEmployeeEntryExitMapper mapper, IEmployeeService employeeService)
	{
		_service = service;
		_mapper = mapper;
		_employeeService = employeeService;
	}
	public IActionResult Index()
	{
		var entryExits = _service.GetEmployeeEntryExit();
		var employees = _employeeService.GetEmployees();
		var entryExitDtos = new List<EmployeeEntryExitDTO>();
		foreach (var item in entryExits)
		{
			entryExitDtos.Add(_mapper.FromEmployeeEntryExit(item, employees.ToList()));
		}
		return View(entryExitDtos);
	}
	public IActionResult CreateEmployeeEntryExit()
	{
		EmployeeEntryExitDTO temp = new();
		var employees = _employeeService.GetEmployees();
		ViewBag.Employees = employees;
		return View(temp);
	}
	[HttpPost]
	public IActionResult CreateEmployeeEntryExit(EmployeeEntryExitDTO entryExitDto)
	{
		var employees = _employeeService.GetEmployees();
		ViewBag.Employees = employees;
		if (!ModelState.IsValid)
		{
			return View(entryExitDto);
		}
		var entryExit = _mapper.ToEmployeeEntryExit(entryExitDto, employees.ToList());
		var result = _service.CreateOne(entryExit);
		TempData["Result"] = result;
		return RedirectToAction("Index");
	}
	public IActionResult UpdateEmployeeEntryExit(int id)
	{
		var employees = _employeeService.GetEmployees();
		ViewBag.Employees = employees;
		var entryExit = _service.GetById(id);
		var entryExitDto = _mapper.FromEmployeeEntryExit(entryExit, employees.ToList());
		return View(entryExitDto);
	}
	[HttpPost]
	public IActionResult UpdateEmployeeEntryExit(EmployeeEntryExitDTO entryExitDto)
	{
		var employees = _employeeService.GetEmployees();
		ViewBag.Employees = employees;
		if (!ModelState.IsValid)
		{
			return View(entryExitDto);
		}
		var entryExit = _mapper.ToEmployeeEntryExit(entryExitDto, employees.ToList());
		var result = _service.UpdateOne(entryExit);
		TempData["Result"] = result;
		return RedirectToAction("Index");
	}
	public IActionResult DeleteEmployeeEntryExit(int id)
	{
		var result = _service.DeleteEmployeeEntryExit(id);
		TempData["Result"] = result;
		return RedirectToAction("Index");
	}
}
