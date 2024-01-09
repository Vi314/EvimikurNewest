using Logic.Abstract_Service;
using Logic.Concrete_Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace MVC.Areas.Api {
    //[Authorize]
    [ApiController]
    [Route("Stocks")]
    public class StockController : ControllerBase {
        public StockController(IProductService productService) {
            _productService = productService;
        }
        private IProductService _productService { get; }

        [HttpGet]
        [Route("Get")]
        public string GetStocks() {
            var stocks = _productService.GetAll();
            var stocksJson = JsonConvert.SerializeObject(stocks
                    .Select(x => new { x.Id, x.Category?.Name, x.ProductName, x.Description }));
            return stocksJson;
        }
    }
}
