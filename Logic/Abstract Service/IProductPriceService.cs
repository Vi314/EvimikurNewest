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
		HttpStatusCode CreateRange(IEnumerable<ProductPrice> Thing);
		HttpStatusCode UpdateRange(IEnumerable<ProductPrice> Thing);
		HttpStatusCode DeleteRange(IEnumerable<int> id);
		HttpStatusCode CreateOne(ProductPrice thing);
		HttpStatusCode UpdateOne(ProductPrice thing);
		HttpStatusCode DeleteOne(int id);
		IEnumerable<ProductPrice> GetAll();
		ProductPrice GetById(int id);
	}
}
