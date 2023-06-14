using Entity.ConnectionEntity;
using Logic.Abstract_Generic;
using System.Net;

namespace Logic.Abstract_Service;

public interface ISalesAndProductsService:IBaseService<SalesAndProductsModel>
{
    IEnumerable<SalesAndProductsModel> GetAll(int id);
}