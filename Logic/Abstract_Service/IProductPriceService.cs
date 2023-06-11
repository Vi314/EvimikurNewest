using Entity.Entity;
using System.Net;

namespace Logic.Abstract_Service
{
    public interface IProductPriceService
    {
        HttpStatusCode CreateRange(IEnumerable<ProductPriceModel> Thing);

        HttpStatusCode UpdateRange(IEnumerable<ProductPriceModel> Thing);

        HttpStatusCode DeleteRange(IEnumerable<int> id);

        HttpStatusCode CreateOne(ProductPriceModel thing, IEnumerable<int> dealerIds);

        HttpStatusCode UpdateOne(ProductPriceModel thing, IEnumerable<int> dealerIds);

        HttpStatusCode DeleteOne(int id);

        IEnumerable<ProductPriceModel> GetAll();

        ProductPriceModel GetById(int id);
    }
}