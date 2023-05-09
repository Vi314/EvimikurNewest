using Entity.Entity;
using MVC.Areas.Entities.Models.MapperAbstract;
using MVC.Areas.Entities.Models.ViewModels;

namespace MVC.Areas.Entities.Models.MapperConcrete
{
	public class DealerStocksMapper : IDealerStocksMapper
	{
		public DealerStockDTO FromDealerStock(DealerStocks dealerStocks, IEnumerable<Product> products,IEnumerable<Dealer> dealers, IEnumerable<Supplier> suppliers)
		{
			DealerStockDTO dealerStockDTO = new DealerStockDTO
			{
				Id = dealerStocks.Id,
				Amount = dealerStocks.Amount,
				MinimumAmount= dealerStocks.MinimumAmount,
				Cost = dealerStocks.Cost,
			};
			if (dealerStocks.ProductId != null)
			{
				dealerStockDTO.ProductName = products.Where(x => x.Id == dealerStocks.ProductId).Select(x => x.ProductName).FirstOrDefault();
			};
			if (dealerStocks.DealerId != null)
			{
				dealerStockDTO.DealerName = dealers.Where(x => x.Id == dealerStocks.DealerId).Select(x => x.Name).FirstOrDefault();
			};
            if (dealerStocks.SupplierId != null)
            {
                dealerStockDTO.SupplierName = suppliers.Where(x => x.Id == dealerStocks.SupplierId).Select(x => x.CompanyName).FirstOrDefault();
            };
            return dealerStockDTO;
		}

		public DealerStocks ToDealerStock(DealerStockDTO dealerStocksDTO, IEnumerable<Product> products, IEnumerable<Dealer> dealers, IEnumerable<Supplier> suppliers)
		{
			DealerStocks dealerStocks = new DealerStocks
			{
				Id = dealerStocksDTO.Id,
				Amount = dealerStocksDTO.Amount,
				MinimumAmount= dealerStocksDTO.MinimumAmount,
				Cost= dealerStocksDTO.Cost,
				ProductId = products.Where(x => x.ProductName == dealerStocksDTO.ProductName).Select(x => x.Id).FirstOrDefault(),
				DealerId = dealers.Where(x => x.Name == dealerStocksDTO.DealerName).Select(x => x.Id).FirstOrDefault(),
				SupplierId = suppliers.Where(x => x.CompanyName == dealerStocksDTO.SupplierName).Select(x => x.Id).FirstOrDefault(),
            };
			return dealerStocks;
		}
	}
}
