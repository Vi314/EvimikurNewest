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
		HttpStatusCode Create(Sale sale);
		HttpStatusCode Create(Sale sale, List<int> dealerids, List<int> productids);

		HttpStatusCode Update(Sale sale);
		HttpStatusCode Update(Sale sale, List<int> dealerids, List<int> productids);

		HttpStatusCode Delete(int id);
		
		HttpStatusCode CreateRange(IEnumerable<Sale> Thing);
		HttpStatusCode UpdateRange(IEnumerable<Sale> Thing);
		HttpStatusCode DeleteRange(IEnumerable<int> id);

		void CreateDealerConnections(int id, List<int> dealerids);
		void UpdateDealerConnections(int id, List<int> dealerids); 
		void DeleteDealerConnections(int id);

		void CreateProductConnections(int id, List<int> productids);
		void UpdateProductConnections(int id, List<int> productids);
		void DeleteProductConnections(int id);


		Sale GetById(int id);
		IEnumerable<Sale> GetAll();
		int ExecuteRawSql(string command);
	}
}
