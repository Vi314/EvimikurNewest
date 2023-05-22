using Entity.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Abstract_Repository
{
	public interface IProductRepository
	{
		string Create(Product product);
		string Update(Product product);
		string Delete(int id);
		Product GetById(int id);
		IEnumerable<Product> GetAll();
		int ExecuteRawSql(string command);
	}
}
