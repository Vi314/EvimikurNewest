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
		HttpStatusCode Create(DealerStocks dealerStocks);
		HttpStatusCode Update(DealerStocks dealerStocks);
		HttpStatusCode Delete(int id);
		HttpStatusCode CreateRange(IEnumerable<DealerStocks> Thing);
		HttpStatusCode UpdateRange(IEnumerable<DealerStocks> Thing);
		HttpStatusCode DeleteRange(IEnumerable<int> id);

		DealerStocks GetById(int id);
		IEnumerable<DealerStocks> GetAll();
		int ExecuteRawSql(string command);
	}
}
