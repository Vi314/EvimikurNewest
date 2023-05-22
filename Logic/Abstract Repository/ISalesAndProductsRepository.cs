using Entity.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Abstract_Repository
{
	public interface ISalesAndProductsRepository
	{
		string Create(SalesAndProducts salesAndProducts);
		string Update(SalesAndProducts salesAndProducts);
		string Delete(int id);
		SalesAndProducts GetById(int id);
		IEnumerable<SalesAndProducts> GetAll();
		int ExecuteRawSql(string command);
	}
}
