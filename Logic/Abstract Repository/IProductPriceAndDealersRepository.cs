using Entity.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Abstract_Repository;

public interface IProductPriceAndDealersRepository
{
	HttpStatusCode Create(ProductPriceAndDealers Thing);
	HttpStatusCode Update(ProductPriceAndDealers Thing);
	HttpStatusCode Delete(int id);
	HttpStatusCode CreateRange(IEnumerable<ProductPriceAndDealers> Thing);
	HttpStatusCode UpdateRange(IEnumerable<ProductPriceAndDealers> Thing);
	HttpStatusCode DeleteRange(IEnumerable<int> id);

	ProductPriceAndDealers GetById(int id);
	IEnumerable<ProductPriceAndDealers> GetAll();
	int ExecuteRawSql(string command);
}
