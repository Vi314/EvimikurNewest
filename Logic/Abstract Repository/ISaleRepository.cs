using Entity.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Abstract_Repository
{
	public interface ISaleRepository
	{
		HttpStatusCode Create(SaleModel sale);
		HttpStatusCode Create(SaleModel sale, List<int> dealerids, List<int> productids);

		HttpStatusCode Update(SaleModel sale);
		HttpStatusCode Update(SaleModel sale, List<int> dealerids, List<int> productids);

		HttpStatusCode Delete(int id);
		
		HttpStatusCode CreateRange(IEnumerable<SaleModel> Thing);
		HttpStatusCode UpdateRange(IEnumerable<SaleModel> Thing);
		HttpStatusCode DeleteRange(IEnumerable<int> id);

		void UpdateDealerConnections(int id, List<int> dealerids); 
		void UpdateProductConnections(int id, List<int> productids);


		SaleModel GetById(int id);
		IEnumerable<SaleModel> GetAll();
		int ExecuteRawSql(string command);
	}
}
