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
		HttpStatusCode Create(OrderModel order);
		HttpStatusCode Update(OrderModel order);
		HttpStatusCode Delete(int id);
		HttpStatusCode CreateRange(IEnumerable<OrderModel> Thing);
		HttpStatusCode UpdateRange(IEnumerable<OrderModel> Thing);
		HttpStatusCode DeleteRange(IEnumerable<int> id);

		OrderModel GetById(int id);
		IEnumerable<OrderModel> GetAll();
		int ExecuteRawSql(string command);
	}
}
