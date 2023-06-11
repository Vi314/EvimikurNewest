using Entity.Entity;
using System.Net;

namespace Logic.Abstract_Service;

public interface ISupplierService
{
    HttpStatusCode CreateRange(IEnumerable<SupplierModel> Thing);

    HttpStatusCode UpdateRange(IEnumerable<SupplierModel> Thing);

    HttpStatusCode DeleteRange(IEnumerable<int> id);

    HttpStatusCode CreateOne(SupplierModel supplier);

    HttpStatusCode UpdateOne(SupplierModel supplier);

    HttpStatusCode DeleteSupplier(int id);

    IEnumerable<SupplierModel> GetSuppliers();

    SupplierModel GetById(int id);
}