using Entity.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Abstract_Service
{
	public interface IProductPriceService
	{
		HttpStatusCode CreateRange(IEnumerable<ProductPriceModel> Thing);
		HttpStatusCode UpdateRange(IEnumerable<ProductPriceModel> Thing);
		HttpStatusCode DeleteRange(IEnumerable<int> id);
		HttpStatusCode CreateOne(ProductPriceModel thing);
		HttpStatusCode UpdateOne(ProductPriceModel thing);
		HttpStatusCode DeleteOne(int id);
		IEnumerable<ProductPriceModel> GetAll();
		ProductPriceModel GetById(int id);
	}
}
