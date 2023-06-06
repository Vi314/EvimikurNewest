using Entity.Entity;
using Entity.Non_Db_Objcets;
using Microsoft.CodeAnalysis;
using MVC.Areas.Entities.Models.MapperAbstract;
using MVC.Areas.Entities.Models.ViewModels;

namespace MVC.Areas.Entities.Models.MapperConcrete
{
    public class StockTransferMapper : IStockTransferMapper
    {
        public StockTransferDTO FromStockTransferObject(StockTransferObject transferObject, IEnumerable<ProductModel> products, IEnumerable<DealerModel> dealers)
        {
            var transferDTO = new StockTransferDTO
            {
                Amount = transferObject.Quantity,
                FromDealerName = dealers.Where(x => x.Id == transferObject.FromDealerId).Select(x => x.Name).FirstOrDefault(),
                ToDealerName = dealers.Where(x => x.Id == transferObject.ToDealerId).Select(x => x.Name).FirstOrDefault(),
                ProductName = products.Where(x => x.Id == transferObject.ProductId).Select(x => x.ProductName).FirstOrDefault(),
            };
            return transferDTO;
        }

        public StockTransferObject ToStockTransferObject(StockTransferDTO stockTransferDTO, IEnumerable<ProductModel> products, IEnumerable<DealerModel> dealers)
        {
            var transferObject = new StockTransferObject
            {
                Quantity = stockTransferDTO.Amount,
                FromDealerId = dealers.Where(x => x.Name == stockTransferDTO.FromDealerName).Select(x => x.Id).FirstOrDefault(),
                ToDealerId = dealers.Where(x => x.Name == stockTransferDTO.ToDealerName).Select(x => x.Id).FirstOrDefault(),
                ProductId = products.Where(x => x.ProductName == stockTransferDTO.ProductName).Select(x => x.Id).FirstOrDefault(),
            };
            return transferObject;
        }
    }
}