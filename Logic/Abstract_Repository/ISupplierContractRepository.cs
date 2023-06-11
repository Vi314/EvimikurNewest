using Entity.Entity;
using System.Net;

namespace Logic.Abstract_Repository
{
    public interface ISupplierContractRepository
    {
        HttpStatusCode Create(SupplierContractModel supplierContract);

        HttpStatusCode Update(SupplierContractModel supplierContract);

        HttpStatusCode Delete(int id);

        HttpStatusCode CreateRange(IEnumerable<SupplierContractModel> Thing);

        HttpStatusCode UpdateRange(IEnumerable<SupplierContractModel> Thing);

        HttpStatusCode DeleteRange(IEnumerable<int> id);

        SupplierContractModel GetById(int id);

        IEnumerable<SupplierContractModel> GetAll();

        int ExecuteRawSql(string command);
    }
}