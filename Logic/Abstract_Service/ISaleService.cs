using Entity.Entity;
using Logic.Abstract_Generic;
using System.Net;

namespace Logic.Abstract_Service;

public interface ISaleService:IBaseService<SaleModel>
{
    public HttpStatusCode Create(SaleModel sale, List<int> dealerId, List<int> productId);
    public HttpStatusCode Update(SaleModel sale, List<int> dealerId, List<int> productId);
}