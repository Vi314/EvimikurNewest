using Entity.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Abstract_Repository
{
	public interface ISupplierContractRepository
	{
		HttpStatusCode Create(SupplierContract supplierContract);
		HttpStatusCode Update(SupplierContract supplierContract);
		HttpStatusCode Delete(int id);
		HttpStatusCode CreateRange(IEnumerable<SupplierContract> Thing);
		HttpStatusCode UpdateRange(IEnumerable<SupplierContract> Thing);
		HttpStatusCode DeleteRange(IEnumerable<int> id);

		SupplierContract GetById(int id);
		IEnumerable<SupplierContract> GetAll();
		int ExecuteRawSql(string command);
	}
}
