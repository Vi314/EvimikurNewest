using Entity.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Abstract_Service
{
	public interface ISalesAndDealersService
	{
		IEnumerable<SalesAndDealers> GetAll();
		SalesAndDealers GetById();
		string Create();
		string Update();
		string Delete();

	}
}
