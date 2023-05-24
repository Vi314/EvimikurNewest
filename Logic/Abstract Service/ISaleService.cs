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
	HttpStatusCode CreateRange(IEnumerable<Sale> Thing);
	HttpStatusCode UpdateRange(IEnumerable<Sale> Thing);
	HttpStatusCode DeleteRange(IEnumerable<int> id);

	HttpStatusCode CreateOne(Sale sale, List<int> dealerId, List<int> productId);
	HttpStatusCode UpdateOne(Sale sale, List<int> dealerId, List<int> productId);
	HttpStatusCode DeleteOne(int id);
	IEnumerable<Sale> GetAll();
	Sale GetById(int id);
}
