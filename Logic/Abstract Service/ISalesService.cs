using Entity.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Abstract_Service
{
	public interface ISalesService
	{
		public Sale GetById(int id);
		public IEnumerable<Sale> GetAll();
		public string CreateSale(Sale sale);
		public string UpdateSale(Sale sale);
		public string DeleteSale(int id);
	}
}
