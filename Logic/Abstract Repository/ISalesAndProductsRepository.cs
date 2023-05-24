using Entity.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Abstract_Repository
{
	public interface ISalesAndProductsRepository
	{
		HttpStatusCode Create(SalesAndProducts salesAndProducts);
		HttpStatusCode Update(SalesAndProducts salesAndProducts);
		HttpStatusCode Delete(int id);
		HttpStatusCode CreateRange(IEnumerable<SalesAndProducts> Thing);
		HttpStatusCode UpdateRange(IEnumerable<SalesAndProducts> Thing);
		HttpStatusCode DeleteRange(IEnumerable<int> id);

		SalesAndProducts GetById(int id);
		IEnumerable<SalesAndProducts> GetAll();
		int ExecuteRawSql(string command);
	}
}
