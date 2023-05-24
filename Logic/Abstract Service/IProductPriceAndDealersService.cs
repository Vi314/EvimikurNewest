using Entity.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Abstract_Service
{
	public interface IProductPriceAndDealersService
	{
		HttpStatusCode CreateRange(IEnumerable<ProductPriceAndDealers> Thing);
		HttpStatusCode UpdateRange(IEnumerable<ProductPriceAndDealers> Thing);
		HttpStatusCode DeleteRange(IEnumerable<int> id);
		HttpStatusCode CreateOne(ProductPriceAndDealers thing);
		HttpStatusCode UpdateOne(ProductPriceAndDealers thing);
		HttpStatusCode DeleteOne(int id);
		IEnumerable<ProductPriceAndDealers> GetAll();
		ProductPriceAndDealers GetById(int id);
	}
}
