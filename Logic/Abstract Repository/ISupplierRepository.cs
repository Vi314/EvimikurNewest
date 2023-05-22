using Entity.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Abstract_Repository
{
	public interface ISupplierRepository
	{
		string Create(Supplier supplier);
		string Update(Supplier supplier);
		string Delete(int id);
		Supplier GetById(int id);
		IEnumerable<Supplier> GetAll();
		int ExecuteRawSql(string command);
	}
}
