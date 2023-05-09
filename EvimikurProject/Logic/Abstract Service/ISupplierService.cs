using Entity.Entity;

namespace Logic.Abstract_Service;

public interface ISupplierService
{
	string CreateSupplier(Supplier supplier);
	string UpdateSupplier(Supplier supplier);
	string DeleteSupplier(int id);
	IEnumerable<Supplier> GetSuppliers();
	Supplier GetById(int id);
}