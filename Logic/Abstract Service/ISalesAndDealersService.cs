using Entity.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Abstract_Service;

public interface ISalesAndDealersService
{
	HttpStatusCode CreateRange(IEnumerable<SalesAndDealers> Thing);
	HttpStatusCode UpdateRange(IEnumerable<SalesAndDealers> Thing);
	HttpStatusCode DeleteRange(IEnumerable<int> id);

	IEnumerable<SalesAndDealers> GetAll();
	IEnumerable<SalesAndDealers> GetAll(int saleId);
	SalesAndDealers GetById(int id);
	HttpStatusCode Create(SalesAndDealers salesAndDealers);
	HttpStatusCode Update(SalesAndDealers salesAndDealers);
	HttpStatusCode Delete(int id);

}
