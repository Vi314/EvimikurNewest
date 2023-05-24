using Entity.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Abstract_Repository;
public interface ISalesAndDealersRepository
{
	HttpStatusCode Create(SalesAndDealers salesAndDealers);
	HttpStatusCode Update(SalesAndDealers salesAndDealers);
	HttpStatusCode Delete(int id);
	HttpStatusCode CreateRange(IEnumerable<SalesAndDealers> Thing);
	HttpStatusCode UpdateRange(IEnumerable<SalesAndDealers> Thing);
	HttpStatusCode DeleteRange(IEnumerable<int> id);

	SalesAndDealers GetById(int id);
	IEnumerable<SalesAndDealers> GetAll();
	IEnumerable<SalesAndDealers> GetAll(int saleId);
	int ExecuteRawSql(string command);
}
