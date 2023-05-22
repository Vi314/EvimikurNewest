using Entity.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Abstract_Repository
{
	public interface ISaleRepository
	{
		string Create(Sale sale);
		string Update(Sale sale);
		string Delete(int id);
		Sale GetById(int id);
		IEnumerable<Sale> GetAll();
		int ExecuteRawSql(string command);
	}
}
