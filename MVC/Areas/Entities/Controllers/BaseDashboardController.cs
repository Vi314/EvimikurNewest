using Entity.Base;
using Logic;
using Logic.Abstract_Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MVC.Areas.Entities.Models.ViewModels;

namespace MVC.Areas.Entities.Controllers;

[Authorize]
public class BaseDashboardController<Model, Service, Dto, Mapper> : Controller 
    where Model : BaseEntity
    where Service : IBaseInterface<Model>
    where Dto : BaseDTO
    where Mapper : class
{
    private readonly Service _service;
    public BaseDashboardController(Service service)
    {
        _service = service;
    }
    
    [HttpGet]
    public virtual IActionResult Index()
    {
        var entityList = _service.GetAll().ToList();

        return View(entityList);
    }

    public virtual IActionResult Create()
    {

        return View();
    }

    public virtual IActionResult Update()
    {
        return View();
    }

    public virtual IActionResult Delete()
    {
        return View();
    }

}
