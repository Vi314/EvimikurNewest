using Entity.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Abstract_Service;

public interface ISaleService
{
	HttpStatusCode CreateRange(IEnumerable<SaleModel> Thing);
	HttpStatusCode UpdateRange(IEnumerable<SaleModel> Thing);
	HttpStatusCode DeleteRange(IEnumerable<int> id);

	HttpStatusCode CreateOne(SaleModel sale, List<int> dealerId, List<int> productId);
	HttpStatusCode UpdateOne(SaleModel sale, List<int> dealerId, List<int> productId);
	HttpStatusCode DeleteOne(int id);
	IEnumerable<SaleModel> GetAll();
	SaleModel GetById(int id);
}
