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
		HttpStatusCode Create(Dealer dealer);
		HttpStatusCode Update(Dealer dealer);
		HttpStatusCode Delete(int id);
		HttpStatusCode CreateRange(IEnumerable<Dealer> Thing);
		HttpStatusCode UpdateRange(IEnumerable<Dealer> Thing);
		HttpStatusCode DeleteRange(IEnumerable<int> id);

		Dealer GetById(int id);
		IEnumerable<Dealer> GetAll();
		int ExecuteRawSql(string command);
	}
}
