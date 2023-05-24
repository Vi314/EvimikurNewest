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
		HttpStatusCode Create(Category category);
		HttpStatusCode Update(Category category);
		HttpStatusCode Delete(int id);
		HttpStatusCode CreateRange(IEnumerable<Category> Thing);
		HttpStatusCode UpdateRange(IEnumerable<Category> Thing);
		HttpStatusCode DeleteRange(IEnumerable<int> id);

		Category GetById(int id);
		IEnumerable<Category> GetAll();
		int ExecuteRawSql(string command);

	}
}
