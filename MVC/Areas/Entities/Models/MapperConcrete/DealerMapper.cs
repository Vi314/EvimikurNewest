using Entity.Entity;
using MVC.Areas.Entities.Models.MapperAbstract;
using MVC.Areas.Entities.Models.ViewModels;

namespace MVC.Areas.Entities.Models.MapperConcrete
{
	public class DealerMapper : IDealerMapper
	{

        public Dealer FromDto(DealerDTO dealerDTO)
        {
            Dealer dealer = new Dealer
            {
                Id = dealerDTO.Id,
                Name = dealerDTO.Name.Trim(),
                FullAdress = dealerDTO.FullAddress.Trim()
            };

            return dealer;
        }

        public IEnumerable<Dealer> FromDtoRange(IEnumerable<DealerDTO> entities)
        {
            List<Dealer> dealers = new();

            foreach (var item in entities)
            {
                dealers.Add(FromDto(item));
            }

            return dealers;
        }

        public DealerDTO FromEntity(Dealer dealer)
        {
            DealerDTO dealerDTO = new DealerDTO
            {
                Id = dealer.Id,
                Name = dealer.Name,
                FullAddress = dealer.FullAdress
            };
            return dealerDTO;
        }

        public IEnumerable<DealerDTO> FromEntityRange(IEnumerable<Dealer> entities)
        {
            List<DealerDTO> dealerDTOs = new();
            
            foreach(var item in entities)
            {
                dealerDTOs.Add(FromEntity(item));
            }

            return dealerDTOs;
        }

	}
}
