using Entity.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Abstract_Repository
{
	public interface IOrderDetailsRepository
	{
		HttpStatusCode Create(OrderDetails orderDetails);
		HttpStatusCode Update(OrderDetails orderDetails);
		HttpStatusCode Delete(int id);
		HttpStatusCode CreateRange(IEnumerable<OrderDetails> Thing);
		HttpStatusCode UpdateRange(IEnumerable<OrderDetails> Thing);
		HttpStatusCode DeleteRange(IEnumerable<int> id);

		OrderDetails GetById(int id);
		IEnumerable<OrderDetails> GetAll();
		int ExecuteRawSql(string command);
	}
}
