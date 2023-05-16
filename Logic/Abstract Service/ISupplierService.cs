using Entity.Entity;

namespace Logic.Abstract_Service;

public interface ISupplierService
{
	string CreateOne(Supplier supplier);
	string UpdateOne(Supplier supplier);
	string DeleteSupplier(int id);
	IEnumerable<Supplier> GetSuppliers();
	Supplier GetById(int id);
}