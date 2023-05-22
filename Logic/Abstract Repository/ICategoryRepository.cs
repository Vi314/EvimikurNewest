using Entity.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Abstract_Repository
{
	public interface ICategoryRepository
	{
		string Create(Category category);
		string Update(Category category);
		string Delete(int id);
		Category GetById(int id);
		IEnumerable<Category> GetAll();
		int ExecuteRawSql(string command);

	}
}
