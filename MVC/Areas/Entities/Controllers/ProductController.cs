using Entity.Entity;
using Logic.Abstract_Service;
using Microsoft.AspNetCore.Mvc;
using MVC.Areas.Entities.BaseControllers;
using MVC.Areas.Entities.Models.MapperAbstract;
using MVC.Areas.Entities.Models.ViewModels;

namespace MVC.Areas.Entities.Controllers
{
    [Area("Entities")]
    public class ProductController : BaseDashboardController<ProductModel, IProductService, ProductDto, IProductMapper>
    {
        private readonly IProductService _service;
        private readonly ICategoryService _categoryService;
        private readonly IProductMapper _mapper;

        public ProductController(IProductService service, IProductMapper mapper, ICategoryService categoryService) : base (service, mapper)
        {
            _service = service;
            _mapper = mapper;
            _categoryService = categoryService;
        }

        public override void PopulateData()
        {
            ViewBag.Categories = _categoryService.GetAll().ToList();
        }
        
    }
}