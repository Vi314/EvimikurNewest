using Entity.Entity;
using MVC.Areas.Entities.Models.MapperAbstract;
using MVC.Areas.Entities.Models.ViewModels;

namespace MVC.Areas.Entities.Models.MapperConcrete
{
    public class DealerMapper : IDealerMapper
    {
        public DealerModel FromDto(DealerDto dealerDTO)
        {
            var dealer = new DealerModel
            {
                Id = dealerDTO.Id,
                Name = dealerDTO.Name.Trim(),
                FullAdress = dealerDTO.FullAddress.Trim()
            };

            return dealer;
        }

        public IEnumerable<DealerModel> FromDtoRange(IEnumerable<DealerDto> entities)
        {
            List<DealerModel> dealers = new();

            foreach (var item in entities)
            {
                dealers.Add(FromDto(item));
            }

            return dealers;
        }

        public DealerDto FromEntity(DealerModel dealer)
        {
            var dealerDTO = new DealerDto
            {
                Id = dealer.Id,
                Name = dealer.Name,
                FullAddress = dealer.FullAdress
            };
            return dealerDTO;
        }

        public IEnumerable<DealerDto> FromEntityRange(IEnumerable<DealerModel> entities)
        {
            List<DealerDto> dealerDTOs = new();

            foreach (var item in entities)
            {
                dealerDTOs.Add(FromEntity(item));
            }

            return dealerDTOs;
        }
    }
}