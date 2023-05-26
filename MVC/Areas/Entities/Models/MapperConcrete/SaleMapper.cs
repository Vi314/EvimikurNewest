using Entity.Entity;
using MVC.Areas.Entities.Models.MapperAbstract;
using MVC.Areas.Entities.Models.ViewModels;

namespace MVC.Areas.Entities.Models.MapperConcrete
{
	public class SaleMapper : ISaleMapper
	{
		public SaleDTO FromEntity(Sale sale)     
		{
			var saleDto = new SaleDTO
			{
				Description = sale.Description,
				Discount = sale.Discount,
				EndDate = sale.EndDate,
				StartDate = sale.StartDate,
				Id = sale.Id,
				IsForAllDealers = sale.IsForAllDealers,
				IsForAllProducts = sale.IsForAllProducts,
				
			};

			return saleDto;
		}

		public Sale FromDto(SaleDTO saleDto)
		{
			var sale = new Sale
			{
				Discount = saleDto.Discount,
				Description = saleDto.Description == null ? "" : saleDto.Description.Trim() ,
				StartDate = saleDto.StartDate,
				EndDate= saleDto.EndDate,
				Id = saleDto.Id,
				IsForAllDealers = saleDto.IsForAllDealers,	
				IsForAllProducts= saleDto.IsForAllProducts,

			};

			return sale;
		}
	}
}
