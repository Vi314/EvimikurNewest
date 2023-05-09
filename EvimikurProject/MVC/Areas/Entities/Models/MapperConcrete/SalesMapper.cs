using Entity.Entity;
using MVC.Areas.Entities.Models.MapperAbstract;
using MVC.Areas.Entities.Models.ViewModels;

namespace MVC.Areas.Entities.Models.MapperConcrete
{
	public class SalesMapper : ISalesMapper
	{
		public SalesDTO FromSale(Sale sale)
		{
			var SalesDTO = new SalesDTO
			{
				EndDate = sale.EndDate.ToString().Replace("00:00:00", ""),
				StartDate = sale.StartDate.ToString().Replace("00:00:00", ""),
			};
			if (sale.Dealer != null)
			{
				foreach (var item in sale.Dealer)
				{
					SalesDTO.DealerNames.Add(item.Name);
				}
			}
			return SalesDTO;
		}

		public Sale ToSale(SalesDTO salesDTO, List<Dealer> dealers, List<Product> products)
		{
			throw new NotImplementedException();
		}
	}
}
