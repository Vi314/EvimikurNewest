using Entity.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Abstract_Repository
{
	public interface IDealerRepository
	{
		HttpStatusCode Create(DealerModel dealer);
		HttpStatusCode Update(DealerModel dealer);
		HttpStatusCode Delete(int id);
		HttpStatusCode CreateRange(IEnumerable<DealerModel> Thing);
		HttpStatusCode UpdateRange(IEnumerable<DealerModel> Thing);
		HttpStatusCode DeleteRange(IEnumerable<int> id);

		DealerModel GetById(int id);
		IEnumerable<DealerModel> GetAll();
		int ExecuteRawSql(string command);
	}
}
