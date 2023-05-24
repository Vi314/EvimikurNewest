using Entity.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Abstract_Repository
{
	public interface IProductRepository
	{
		HttpStatusCode Create(Product product);
		HttpStatusCode Update(Product product);
		HttpStatusCode Delete(int id);
		HttpStatusCode CreateRange(IEnumerable<Product> Thing);
		HttpStatusCode UpdateRange(IEnumerable<Product> Thing);
		HttpStatusCode DeleteRange(IEnumerable<int> id);

		Product GetById(int id);
		IEnumerable<Product> GetAll();
		int ExecuteRawSql(string command);
	}
}
