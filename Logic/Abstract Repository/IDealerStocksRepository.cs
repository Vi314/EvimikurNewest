using Entity.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Abstract_Repository
{
	public interface IDealerStocksRepository
	{
		string Create(DealerStocks dealerStocks);
		string Update(DealerStocks dealerStocks);
		string Delete(int id);
		DealerStocks GetById(int id);
		IEnumerable<DealerStocks> GetAll();
		int ExecuteRawSql(string command);
	}
}
