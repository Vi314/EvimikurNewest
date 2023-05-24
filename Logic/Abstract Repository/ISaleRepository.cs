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
		HttpStatusCode Update(Sale sale);
		HttpStatusCode Delete(int id);
		HttpStatusCode CreateRange(IEnumerable<Sale> Thing);
		HttpStatusCode UpdateRange(IEnumerable<Sale> Thing);
		HttpStatusCode DeleteRange(IEnumerable<int> id);

		Sale GetById(int id);
		IEnumerable<Sale> GetAll();
		int ExecuteRawSql(string command);
	}
}
