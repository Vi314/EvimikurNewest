using Entity.Entity;
using Logic.Abstract_Generic;
using Logic.Abstract_Service;
using Logic.Concrete_Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MVC.Areas.Entities.Models.MapperAbstract;
using MVC.Areas.Entities.Models.ViewModels;

namespace MVC.Areas.Entities.Controllers;

[Area("Entities")]
public class CategoryController : BaseDashboardController<CategoryDTO, CategoryModel, ICategoryService>
{
    private readonly ICategoryService service;

    public CategoryController(ICategoryService service) : base(service)
    {
        this.service = service;
    }

    //public IActionResult CreateCategory()
    //{
    //    CategoryDTO categoryDTO = new();
    //    return View(categoryDTO);
    //}

    //[HttpPost]
    //public IActionResult CreateCategory(CategoryDTO categoryDTO)
    //{
    //    if (!ModelState.IsValid)
    //    {
    //        return View(categoryDTO);
    //    }
    //    var category = _categoryMapper.FromDto(categoryDTO);
    //    var result = _service.CreateOne(category);
    //    TempData["Result"] = result;
    //    return RedirectToAction("Index");
    //}

    //public IActionResult Index()
    //{
    //    var categories = _service.GetCategories();
    //    var categoryDTOs = new List<CategoryDTO>();
    //    foreach (var item in categories)
    //    {
    //        if (item.State != Microsoft.EntityFrameworkCore.EntityState.Deleted)
    //        {
    //            categoryDTOs.Add(_categoryMapper.FromEntity(item));
    //        }
    //    }
    //    return View(categoryDTOs);
    //}

    //public IActionResult UpdateCategory(int id)
    //{
    //    var category = _service.GetById(id);
    //    var categoryDTO = _categoryMapper.FromEntity(category);
    //    return View(categoryDTO);
    //}

    //[HttpPost]
    //public IActionResult UpdateCategory(CategoryDTO categoryDTO)
    //{
    //    if (!ModelState.IsValid)
    //    {
    //        return View(categoryDTO);
    //    }
    //    var category = _categoryMapper.FromDto(categoryDTO);
    //    var result = _service.UpdateOne(category);
    //    TempData["Result"] = result;
    //    return RedirectToAction("Index");
    //}

    //public IActionResult DeleteCategory(int id)
    //{
    //    var result = _service.DeleteCategory(id);
    //    TempData["Result"] = result;
    //    return RedirectToAction("Index");
    //}
}