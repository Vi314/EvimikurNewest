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
	HttpStatusCode Create(ProductPriceAndDealersModel Thing);
	HttpStatusCode Update(ProductPriceAndDealersModel Thing);
	HttpStatusCode Delete(int id);
	HttpStatusCode CreateRange(IEnumerable<ProductPriceAndDealersModel> Thing);
	HttpStatusCode UpdateRange(IEnumerable<ProductPriceAndDealersModel> Thing);
	HttpStatusCode DeleteRange(IEnumerable<int> id);

	ProductPriceAndDealersModel GetById(int id);
	IEnumerable<ProductPriceAndDealersModel> GetAll();
	int ExecuteRawSql(string command);
}
