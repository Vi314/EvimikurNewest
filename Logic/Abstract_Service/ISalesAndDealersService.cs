using Entity.ConnectionEntity;
using Logic.Abstract_Generic;
using System.Net;

namespace Logic.Abstract_Service;

public interface ISalesAndDealersService:IBaseService<SalesAndDealersModel>
{
    public IEnumerable<SalesAndDealersModel> GetAll(int saleId);
}