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
		HttpStatusCode Create(SupplierModel supplier);
		HttpStatusCode Update(SupplierModel supplier);
		HttpStatusCode Delete(int id);
		HttpStatusCode CreateRange(IEnumerable<SupplierModel> Thing);
		HttpStatusCode UpdateRange(IEnumerable<SupplierModel> Thing);
		HttpStatusCode DeleteRange(IEnumerable<int> id);

		SupplierModel GetById(int id);
		IEnumerable<SupplierModel> GetAll();
		int ExecuteRawSql(string command);
	}
}
