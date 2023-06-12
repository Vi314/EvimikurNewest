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

        /// <summary>
        /// Takes in a userId connected to a suppleir and returns only the Contracts for that user
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        IEnumerable<SupplierContractModel> GetAll(int userId);


        int ExecuteRawSql(string command);
    }
}