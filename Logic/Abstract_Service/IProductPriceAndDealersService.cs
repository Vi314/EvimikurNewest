using Entity.ConnectionEntity;
using System.Net;

namespace Logic.Abstract_Service
{
    public interface IProductPriceAndDealersService
    {
        HttpStatusCode CreateRange(IEnumerable<ProductPriceAndDealersModel> Thing);

        HttpStatusCode UpdateRange(IEnumerable<ProductPriceAndDealersModel> Thing);

        HttpStatusCode DeleteRange(IEnumerable<int> id);

        HttpStatusCode CreateOne(ProductPriceAndDealersModel thing);

        HttpStatusCode UpdateOne(ProductPriceAndDealersModel thing);

        HttpStatusCode DeleteOne(int id);

        IEnumerable<ProductPriceAndDealersModel> GetAll();

        ProductPriceAndDealersModel GetById(int id);
    }
}