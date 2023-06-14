using Entity.Base;
using Logic;
using Logic.Abstract_Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MVC.Areas.Entities.Models.MapperAbstractGeneric;
using MVC.Areas.Entities.Models.ViewModels;

namespace MVC.Areas.Entities.BaseControllers;

[Authorize]
public class BaseDashboardController<Model, Service, Dto, Mapper> : Controller
    where Model : BaseEntity
    where Service : IBaseService<Model>
    where Dto : BaseDto
    where Mapper : IBaseMapper<Dto, Model>
{
    private readonly Service _service;
    private readonly Mapper _mapper;

    public BaseDashboardController(Service service, Mapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }

    [HttpGet]
    [AllowAnonymous]
    public virtual IActionResult Index()
    {
        var entityList = _service.GetAll().ToList();
        var dtoList = _mapper.FromEntityRange(entityList).ToList();
        return View(dtoList);
    }

    [HttpGet]
    public virtual IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public virtual IActionResult Create(Dto dto)
    {
        if (!ModelState.IsValid)
            return View(dto);
        var entity = _mapper.FromDto(dto);
        var result = _service.Create(entity);
        return RedirectToAction("Index");
    }

    [HttpGet]
    public virtual IActionResult Update(int id)
    {
        var entity = _service.GetById(id);
        var dto = _mapper.FromEntity(entity);
        return View(dto);
    }

    [HttpPost]
    public virtual IActionResult Update(Dto dto)
    {
        if (!ModelState.IsValid)
            return View(dto);
        var entity = _mapper.FromDto(dto);
        var result = _service.Update(entity);
        return RedirectToAction("Index");
    }

    public virtual IActionResult Delete(int id)
    {
        var result = _service.Delete(id);
        return RedirectToAction("Index");
    }

}
