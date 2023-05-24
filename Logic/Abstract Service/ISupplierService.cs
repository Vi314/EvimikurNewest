using Entity.Entity;
using System.Net;

namespace Logic.Abstract_Service;

public interface ISupplierService
{
	HttpStatusCode CreateRange(IEnumerable<Supplier> Thing);
	HttpStatusCode UpdateRange(IEnumerable<Supplier> Thing);
	HttpStatusCode DeleteRange(IEnumerable<int> id);
	HttpStatusCode CreateOne(Supplier supplier);
	HttpStatusCode UpdateOne(Supplier supplier);
	HttpStatusCode DeleteSupplier(int id);
	IEnumerable<Supplier> GetSuppliers();
	Supplier GetById(int id);
}