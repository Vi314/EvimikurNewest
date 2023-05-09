﻿using Entity.Entity;
using Logic.Abstract_Service;
using Microsoft.AspNetCore.Mvc;
using MVC.Areas.Entities.Models.ViewModels;
using Microsoft.EntityFrameworkCore;
using MVC.Areas.Entities.Models.MapperAbstract;

namespace MVC.Areas.Entities.Controllers
{
	[Area("Entities")]
	public class ProductController : Controller
    {
	    private readonly IProductService _service;
		private readonly ICategoryService _categoryService;
		private readonly IProductMapper _productMapper;

		public ProductController(IProductService productService,ICategoryService categoryService,IProductMapper productMapper)
	    {
		    _service = productService;
			_categoryService = categoryService;
			_productMapper = productMapper;
		}

		public IActionResult Index()
		{
			var products = _service.GetProducts();
			var categories = _categoryService.GetCategories().ToList();
			List<ProductDTO> productDTOs = new List<ProductDTO>();

			foreach (var item in products)
			{
				if (item.State != EntityState.Deleted)
				{
					productDTOs.Add(_productMapper.FromProduct(item, categories));
				}
			}
			return View(productDTOs);
		}
		public IActionResult CreateProduct()
		{
			ProductDTO productDTO = new();
			ViewBag.Categories = _categoryService.GetCategories().ToList();
			return View(productDTO);
		}
		[HttpPost]
		public IActionResult CreateProduct(ProductDTO productDTO)
		{
			var categories = _categoryService.GetCategories().ToList();
			var product = _productMapper.ToProduct(productDTO, categories);
			var result = _service.CreateProduct(product);
			TempData["Result"] = result;
			return RedirectToAction("Index");
		}

		public IActionResult UpdateProduct(int id)
		{
			var categories = _categoryService.GetCategories().ToList();
			ViewBag.Categories = categories;
			var product = _service.GetById(id);
			var productDTO = _productMapper.FromProduct(product, categories);
			return View(productDTO);
		}
		[HttpPost]
		public IActionResult UpdateProduct(ProductDTO productDTO)
		{
			var categories = _categoryService.GetCategories().ToList();
			var product = _productMapper.ToProduct(productDTO, categories);
			var result = _service.UpdateProduct(product);
			TempData["Result"] = result;
			return RedirectToAction("Index");
		}
		public IActionResult DeleteProduct(int id)
		{
			var result = _service.DeleteProduct(id);
			TempData["Result"] = result;
			return RedirectToAction("Index");
		}
	}
}
