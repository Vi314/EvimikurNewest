using Entity.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Abstract_Repository
{
	public interface IOrderRepository
	{
		string Create(Order order);
		string Update(Order order);
		string Delete(int id);
		Order GetById(int id);
		IEnumerable<Order> GetAll();
		int ExecuteRawSql(string command);
	}
}
