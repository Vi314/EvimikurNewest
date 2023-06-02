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
		HttpStatusCode Create(OrderDetailsModel orderDetails);
		HttpStatusCode Update(OrderDetailsModel orderDetails);
		HttpStatusCode Delete(int id);
		HttpStatusCode CreateRange(IEnumerable<OrderDetailsModel> Thing);
		HttpStatusCode UpdateRange(IEnumerable<OrderDetailsModel> Thing);
		HttpStatusCode DeleteRange(IEnumerable<int> id);

		OrderDetailsModel GetById(int id);
		IEnumerable<OrderDetailsModel> GetAll();
		int ExecuteRawSql(string command);
	}
}
