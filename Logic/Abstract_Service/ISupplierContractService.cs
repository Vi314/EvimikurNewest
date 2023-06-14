using Entity.Entity;
using Logic.Abstract_Generic;
using System.Net;

namespace Logic.Abstract_Service;

public interface ISupplierContractService:IBaseService<SupplierContractModel>
{
    IEnumerable<SupplierContractModel> GetAllByUser(int userId);
}