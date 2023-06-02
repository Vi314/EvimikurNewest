using Entity.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Abstract_Repository
{
	public interface ICategoryRepository
	{
		HttpStatusCode Create(CategoryModel category);
		HttpStatusCode Update(CategoryModel category);
		HttpStatusCode Delete(int id);
		HttpStatusCode CreateRange(IEnumerable<CategoryModel> Thing);
		HttpStatusCode UpdateRange(IEnumerable<CategoryModel> Thing);
		HttpStatusCode DeleteRange(IEnumerable<int> id);

		CategoryModel GetById(int id);
		IEnumerable<CategoryModel> GetAll();
		int ExecuteRawSql(string command);

	}
}
