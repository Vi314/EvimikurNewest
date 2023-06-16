using Entity.Base;
using Logic;
using Logic.Abstract_Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MVC.Areas.Entities.Models.Alerts_And_Messages;
using MVC.Areas.Entities.Models.BaseModels;
using MVC.Areas.Entities.Models.MapperAbstractGeneric;
using MVC.Models;
using System.Net;

namespace MVC.Areas.Entities.BaseControllers;

/// <summary>
/// Base controller class for dashboard functionality, requiring authorization for access.
/// </summary>
/// <typeparam name="Model">The entity model type.</typeparam>
/// <typeparam name="Service">The service interface type.</typeparam>
/// <typeparam name="Dto">The data transfer object type.</typeparam>
/// <typeparam name="Mapper">The mapper interface type.</typeparam>
[Authorize]
public class BaseDashboardController<Model, Service, Dto, Mapper> : Controller
    where Model : BaseEntity
    where Service : IBaseService<Model>
    where Dto : BaseDto
    where Mapper : IBaseMapper<Dto, Model>
{
    private readonly Service _service;
    private readonly Mapper _mapper;

    /// <summary>
    /// Initializes a new instance of the <see cref="BaseDashboardController{Model, Service, Dto, Mapper}"/> class.
    /// </summary>
    /// <param name="service">The service implementation for the entity.</param>
    /// <param name="mapper">The mapper implementation for the entity.</param>
    public BaseDashboardController(Service service, Mapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }

    /// <summary>
    /// Any ViewBag, ViewData or TempData one wishes to have applied for the Create and Update Methods
    /// Is called in the Create and Update methods before the page loads
    /// </summary>
    public virtual void PopulateData()
    {
        //You can add ViewBags, ViewData or TempData to be used here and it will be called on Create and Update methods
    }
    
    #region Swal Configuration

    public virtual string GetModelName()
    {
        return typeof(Model).Name.Replace("Model", "");
    }
    public virtual void ConfigureAlerts(string message)
    {
        TempData["Result"] = new string[1] { message };
    }

    public virtual void ConfigureAlerts(string message, SwalTypes type)
    {
		TempData["Result"] = new string[2]{ message, Enum.GetName(type) };
    }

    public virtual void ConfigureAlerts(string message, SwalTypes type, string header)
    {
		TempData["Result"] = new string[3] { message, nameof(type), header };
    } 
    #endregion

    /// <summary>
    /// Configures the view model for the Views
    /// </summary>
    public virtual void ConfigureViewModel()
    {

	}

    /// <summary>
    /// Displays the view for the index page, showing a list of entities.
    /// </summary>
    /// <returns>The view for the index page, populated with a list of data transfer objects representing the entities.</returns>
    [HttpGet]
    [AllowAnonymous]
    public virtual IActionResult Index()
    {
        var entityList = _service.GetAll().ToList();
        var dtoList = _mapper.FromEntityRange(entityList).ToList();
        return View(dtoList);
    }

    /// <summary>
    /// Displays the view for creating a new entity, populating necessary data.
    /// </summary>
    [HttpGet]
    public virtual IActionResult Create()
    {
        PopulateData();
        return View(Activator.CreateInstance<Dto>());
    }

    /// <summary>
    /// Handles the HTTP POST request for creating a new entity.
    /// </summary>
    /// <param name="dto">The data transfer object containing the entity's data.</param>
    /// <returns>
    /// - If the model state is valid, creates the entity and redirects to the "Index" action.
    /// - If the model state is invalid, populates necessary data and returns the view with the provided data transfer object.
    /// </returns>
    [HttpPost]
    public virtual IActionResult Create(Dto dto)
    {
        if (!ModelState.IsValid)
        {
            PopulateData();
            return View(dto);
        }
        var entity = _mapper.FromDto(dto);
        var result = _service.Create(entity);
        
        if (result != HttpStatusCode.OK)
            ConfigureAlerts($"{GetModelName()} oluşturulurken bir hata oluştu!",SwalTypes.error);

        ConfigureAlerts($"{GetModelName()} başarıyla oluşturuldu!", SwalTypes.success);
        return RedirectToAction("Index");
    }

    /// <summary>
    /// Displays the view for updating an existing entity, populating necessary data.
    /// </summary>
    /// <param name="id">The ID of the entity to update.</param>
    /// <returns>The view for updating the entity with the provided ID.</returns>
    public virtual IActionResult Update(int id)
    {
        PopulateData();
        var entity = _service.GetById(id);
        var dto = _mapper.FromEntity(entity);
        return View(dto);
    }

    /// <summary>
    /// Handles the HTTP POST request for updating an existing entity.
    /// </summary>
    /// <param name="dto">The data transfer object containing the updated entity's data.</param>
    /// <returns>
    /// - If the model state is valid, updates the entity and redirects to the "Index" action.
    /// - If the model state is invalid, populates necessary data and returns the view with the provided data transfer object.
    /// </returns>
    [HttpPost]
    public virtual IActionResult Update(Dto dto)
    {
        if (!ModelState.IsValid)
        {
            PopulateData();
            return View(dto);
        }
        var entity = _mapper.FromDto(dto);
        var result = _service.Update(entity);

		if (result != HttpStatusCode.OK)
			ConfigureAlerts($"{GetModelName()} güncellenirken bir hata oluştu!", SwalTypes.error);

		ConfigureAlerts($"{GetModelName()} başarıyla güncellendi!", SwalTypes.success);

		return RedirectToAction("Index");
    }

    /// <summary>
    /// Deletes the entity with the provided ID and redirects to the "Index" action.
    /// </summary>
    /// <param name="id">The ID of the entity to delete.</param>
    /// <returns>Redirects to the "Index" action.</returns>
    public virtual IActionResult Delete(int id)
    {
        var result = _service.Delete(id);

		if (result != HttpStatusCode.OK)
			ConfigureAlerts($"{GetModelName()} silinirken bir hata oluştu!", SwalTypes.error);

		ConfigureAlerts($"{GetModelName()} başarıyla silindi!", SwalTypes.success);

		return RedirectToAction("Index");
    }
    
}

