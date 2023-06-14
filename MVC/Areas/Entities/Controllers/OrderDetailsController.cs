using Entity.Entity;
using Logic.Abstract_Service;
using Microsoft.AspNetCore.Mvc;
using MVC.Areas.Entities.BaseControllers;
using MVC.Areas.Entities.Models.MapperAbstract;
using MVC.Areas.Entities.Models.ViewModels;

namespace MVC.Areas.Entities.Controllers;

[Area("Entities")]
public class OrderDetailsController : BaseDashboardController<OrderDetailsModel, IOrderDetailsService, OrderDetailsDto, IOrderDetailsMapper>
{
    private readonly IOrderDetailsService _service;
    private readonly IOrderDetailsMapper _orderDetailsMapper;
    private readonly IProductService _productService;
    private readonly IOrderService _orderService;

    public OrderDetailsController(IOrderDetailsService service, IOrderDetailsMapper mapper, IProductService productService, IOrderService orderService) : base (service, mapper)
    {
        _service = service;
        _orderDetailsMapper = mapper;
        _productService = productService;
        _orderService = orderService;
    }

    public override void PopulateData()
    {
        ViewBag.Products = _productService.GetAll().ToList();
        ViewBag.Orders = _orderService.GetAll().ToList();
    }
    
}