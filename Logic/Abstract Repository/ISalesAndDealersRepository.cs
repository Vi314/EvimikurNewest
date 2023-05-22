using Entity.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Abstract_Repository
{
	public interface ISalesAndDealersRepository
	{
		string Create(SalesAndDealers salesAndDealers);
		string Update(SalesAndDealers salesAndDealers);
		string Delete(int id);
		SalesAndDealers GetById(int id);
		IEnumerable<SalesAndDealers> GetAll();
		int ExecuteRawSql(string command);
	}
}
