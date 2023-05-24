using Entity.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Abstract_Repository
{
	public interface IOrderRepository
	{
		HttpStatusCode Create(Order order);
		HttpStatusCode Update(Order order);
		HttpStatusCode Delete(int id);
		HttpStatusCode CreateRange(IEnumerable<Order> Thing);
		HttpStatusCode UpdateRange(IEnumerable<Order> Thing);
		HttpStatusCode DeleteRange(IEnumerable<int> id);

		Order GetById(int id);
		IEnumerable<Order> GetAll();
		int ExecuteRawSql(string command);
	}
}
