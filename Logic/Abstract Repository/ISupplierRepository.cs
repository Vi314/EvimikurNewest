using Entity.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Abstract_Repository
{
	public interface ISupplierRepository
	{
		HttpStatusCode Create(Supplier supplier);
		HttpStatusCode Update(Supplier supplier);
		HttpStatusCode Delete(int id);
		HttpStatusCode CreateRange(IEnumerable<Supplier> Thing);
		HttpStatusCode UpdateRange(IEnumerable<Supplier> Thing);
		HttpStatusCode DeleteRange(IEnumerable<int> id);

		Supplier GetById(int id);
		IEnumerable<Supplier> GetAll();
		int ExecuteRawSql(string command);
	}
}
