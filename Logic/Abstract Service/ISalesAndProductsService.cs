using Entity.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Abstract_Service
{
	public interface ISalesAndProductsService
	{
		IEnumerable<SalesAndProducts> GetAll();
		SalesAndProducts GetById();
		string Create();
		string Update();
		string Delete();
	}
}
