using Entity.Entity;
using Logic.Abstract_Service;
using Microsoft.AspNetCore.Mvc;
using MVC.Areas.Entities.Models.MapperAbstract;
using MVC.Areas.Entities.Models.ViewModels;
using MVC.Models;
using NuGet.Protocol;

namespace MVC.Areas.Entities.Controllers;

[Area("Entities")]
public class CategoryController : Controller
{
    private readonly ICategoryService _service;
    private readonly ICategoryMapper _categoryMapper;

    public CategoryController(ICategoryService service, ICategoryMapper categoryMapper)
    {
        _service = service;
        _categoryMapper = categoryMapper;
    }

    [HttpGet]
    public IActionResult AjaxGet() 
    {
        var categories = _service.GetCategories();
        var categoryDTOs = new List<CategoryDTO>();
        foreach (var item in categories)
        {
            if (item.State != Microsoft.EntityFrameworkCore.EntityState.Deleted)
            {
                categoryDTOs.Add(_categoryMapper.FromEntity(item));
            }
        }
        var x = categoryDTOs.ToJson();
        return Ok(x); 
    }

    public IActionResult CreateCategory()
    {
        CategoryDTO categoryDTO = new();
        return View(categoryDTO);
    }
    [HttpPost]
    public IActionResult CreateCategory(CategoryDTO categoryDTO)
    {
        if (!ModelState.IsValid)
        {
            return View(categoryDTO);
        }
        var category = _categoryMapper.FromDto(categoryDTO);
        var result = _service.CreateOne(category);
        TempData["Result"] = result;
        return RedirectToAction("Index");
    }
    public IActionResult Index()
    {
        var categories = _service.GetCategories();
        var categoryDTOs = new List<CategoryDTO>();
        foreach (var item in categories)
        {
            if (item.State != Microsoft.EntityFrameworkCore.EntityState.Deleted)
            {
                categoryDTOs.Add(_categoryMapper.FromEntity(item));
            }
        }
        return View(categoryDTOs);
    }
    public IActionResult UpdateCategory(int id)
    {
        var category = _service.GetById(id);
        var categoryDTO = _categoryMapper.FromEntity(category);
        return View(categoryDTO);
    }
    [HttpPost]
    public IActionResult UpdateCategory(CategoryDTO categoryDTO)
    {
        if (!ModelState.IsValid)
        {
            return View(categoryDTO);
        }
        var category = _categoryMapper.FromDto(categoryDTO);
        var result = _service.UpdateOne(category);
        TempData["Result"] = result;
        return RedirectToAction("Index");
    }
    public IActionResult DeleteCategory(int id)
    {
        var result = _service.DeleteCategory(id);
        TempData["Result"] = result;
        return RedirectToAction("Index");
    }
}
