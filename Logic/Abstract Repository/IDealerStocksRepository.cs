using Entity.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Abstract_Repository
{
	public interface IDealerStocksRepository
	{
		HttpStatusCode Create(DealerStocksModel dealerStocks);
		HttpStatusCode Update(DealerStocksModel dealerStocks);
		HttpStatusCode Delete(int id);
		HttpStatusCode CreateRange(IEnumerable<DealerStocksModel> Thing);
		HttpStatusCode UpdateRange(IEnumerable<DealerStocksModel> Thing);
		HttpStatusCode DeleteRange(IEnumerable<int> id);

		DealerStocksModel GetById(int id);
		IEnumerable<DealerStocksModel> GetAll();
		int ExecuteRawSql(string command);
	}
}
