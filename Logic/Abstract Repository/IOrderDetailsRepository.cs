using Entity.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Abstract_Repository
{
	public interface IOrderDetailsRepository
	{
		string Create(OrderDetails orderDetails);
		string Update(OrderDetails orderDetails);
		string Delete(int id);
		OrderDetails GetById(int id);
		IEnumerable<OrderDetails> GetAll();
		int ExecuteRawSql(string command);
	}
}
