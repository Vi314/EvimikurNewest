using Entity.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Abstract_Service;
public interface ISalesAndProductsService
{
	HttpStatusCode CreateRange(IEnumerable<SalesAndProductsModel> Thing);
	HttpStatusCode UpdateRange(IEnumerable<SalesAndProductsModel> Thing);
	HttpStatusCode DeleteRange(IEnumerable<int> id);

	IEnumerable<SalesAndProductsModel> GetAll();
	IEnumerable<SalesAndProductsModel> GetAll(int id);
	SalesAndProductsModel GetById(int id);
	HttpStatusCode Create(SalesAndProductsModel salesAndProducts);
	HttpStatusCode Update(SalesAndProductsModel salesAndProducts);
	HttpStatusCode Delete(int id);
}
