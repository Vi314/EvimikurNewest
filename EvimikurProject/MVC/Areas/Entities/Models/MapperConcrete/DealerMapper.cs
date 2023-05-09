﻿using Entity.Entity;
using MVC.Areas.Entities.Models.MapperAbstract;
using MVC.Areas.Entities.Models.ViewModels;

namespace MVC.Areas.Entities.Models.MapperConcrete
{
	public class DealerMapper : IDealerMapper
	{
		public DealerDTO FromDealer(Dealer dealer)
		{
			DealerDTO dealerDTO = new DealerDTO
			{
				Id = dealer.Id,
				Name = dealer.Name,
				FullAddress = dealer.FullAdress
			};
			return dealerDTO;
		}

		public Dealer ToDealer(DealerDTO dealerDTO)
		{
			Dealer dealer = new Dealer
			{
				Id = dealerDTO.Id,
				Name = dealerDTO.Name,
				FullAdress = dealerDTO.FullAddress
			};

			return dealer;
		}
	}
}
