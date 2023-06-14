using Entity.Entity;
using Logic.Abstract_Service;
using Microsoft.AspNetCore.Mvc;
using MVC.Areas.Entities.BaseControllers;
using MVC.Areas.Entities.Models.MapperAbstract;
using MVC.Areas.Entities.Models.ViewModels;

namespace MVC.Areas.Entities.Controllers;

[Area("Entities")]
public class EmployeeEntryExitController : BaseDashboardController<EmployeeEntryExitModel, IEmployeeEntryExitService, EmployeeEntryExitDto, IEmployeeEntryExitMapper>
{
    private readonly IEmployeeEntryExitService _service;
    private readonly IEmployeeEntryExitMapper _mapper;
    private readonly IEmployeeService _employeeService;

    public EmployeeEntryExitController(IEmployeeEntryExitService service, IEmployeeEntryExitMapper mapper, IEmployeeService employeeService) : base(service, mapper)
    {
        _service = service;
        _mapper = mapper;
        _employeeService = employeeService;
    }

    public override void PopulateData()
    {
        ViewBag.Employees = _employeeService.GetAll().ToList();
    }

}