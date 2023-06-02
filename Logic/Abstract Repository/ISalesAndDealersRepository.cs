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
	HttpStatusCode Create(SalesAndDealersModel salesAndDealers);
	HttpStatusCode Update(SalesAndDealersModel salesAndDealers);
	HttpStatusCode Delete(int id);
	HttpStatusCode CreateRange(IEnumerable<SalesAndDealersModel> Thing);
	HttpStatusCode UpdateRange(IEnumerable<SalesAndDealersModel> Thing);
	HttpStatusCode DeleteRange(IEnumerable<int> id);

	SalesAndDealersModel GetById(int id);
	IEnumerable<SalesAndDealersModel> GetAll();
	IEnumerable<SalesAndDealersModel> GetAll(int saleId);
	int ExecuteRawSql(string command);
}
