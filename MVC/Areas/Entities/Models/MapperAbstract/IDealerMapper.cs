using Entity.Entity;
using MVC.Areas.Entities.Models.ViewModels;

namespace MVC.Areas.Entities.Models.MapperAbstract
{
    public interface IDealerMapper
    {
        public DealerModel FromDto(DealerDTO dealerDTO);

        public DealerDTO FromEntity(DealerModel dealer);

        public IEnumerable<DealerDTO> FromEntityRange(IEnumerable<DealerModel> entities);

        public IEnumerable<DealerModel> FromDtoRange(IEnumerable<DealerDTO> entities);
    }
}