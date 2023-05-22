using Entity.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Abstract_Repository
{
	public interface ISupplierContractRepository
	{
		string Create(SupplierContract supplierContract);
		string Update(SupplierContract supplierContract);
		string Delete(int id);
		SupplierContract GetById(int id);
		IEnumerable<SupplierContract> GetAll();
		int ExecuteRawSql(string command);
	}
}
