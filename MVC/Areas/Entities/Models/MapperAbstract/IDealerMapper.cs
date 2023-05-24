using Entity.Entity;
using MVC.Areas.Entities.Models.ViewModels;

namespace MVC.Areas.Entities.Models.MapperAbstract
{
	public interface IDealerMapper
	{
		public Dealer FromDto(DealerDTO dealerDTO);
		public DealerDTO FromEntity(Dealer dealer);
        public IEnumerable<DealerDTO> FromEntityRange(IEnumerable<Dealer> entities);
        public IEnumerable<Dealer> FromDtoRange(IEnumerable<DealerDTO> entities);
    }
}
