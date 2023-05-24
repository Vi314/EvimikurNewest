using Entity.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Abstract_Repository
{
	public interface IProductPriceRepository
	{
		HttpStatusCode Create(ProductPrice Thing);
		HttpStatusCode Update(ProductPrice Thing);
		HttpStatusCode Delete(int id);
		HttpStatusCode CreateRange(IEnumerable<ProductPrice> Thing);
		HttpStatusCode UpdateRange(IEnumerable<ProductPrice> Thing);
		HttpStatusCode DeleteRange(IEnumerable<int> id);

		ProductPrice GetById(int id);
		IEnumerable<ProductPrice> GetAll();
		int ExecuteRawSql(string command);
	}
}
