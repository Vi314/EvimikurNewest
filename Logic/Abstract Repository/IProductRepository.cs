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
		HttpStatusCode Create(ProductModel product);
		HttpStatusCode Update(ProductModel product);
		HttpStatusCode Delete(int id);
		HttpStatusCode CreateRange(IEnumerable<ProductModel> Thing);
		HttpStatusCode UpdateRange(IEnumerable<ProductModel> Thing);
		HttpStatusCode DeleteRange(IEnumerable<int> id);

		ProductModel GetById(int id);
		IEnumerable<ProductModel> GetAll();
		int ExecuteRawSql(string command);
	}
}
