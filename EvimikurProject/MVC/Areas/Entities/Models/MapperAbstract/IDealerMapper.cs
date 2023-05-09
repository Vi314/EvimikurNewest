using Entity.Entity;
using MVC.Areas.Entities.Models.ViewModels;

namespace MVC.Areas.Entities.Models.MapperAbstract
{
	public interface IDealerMapper
	{
		public Dealer ToDealer(DealerDTO dealerDTO);
		public DealerDTO FromDealer(Dealer dealer);
	}
}
