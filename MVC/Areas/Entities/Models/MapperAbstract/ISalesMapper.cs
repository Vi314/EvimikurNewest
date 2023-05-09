using Entity.Entity;
using MVC.Areas.Entities.Models.ViewModels;

namespace MVC.Areas.Entities.Models.MapperAbstract
{
	public interface ISalesMapper
	{
		public Sale ToSale(SalesDTO salesDTO,List<Dealer> dealers, List<Product> products);
		public SalesDTO FromSale(Sale sale);
	}
}
