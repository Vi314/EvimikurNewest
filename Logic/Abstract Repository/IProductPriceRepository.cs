using Entity.Entity;
using System.Net;

namespace Logic.Abstract_Repository
{
    public interface IProductPriceRepository
    {
        HttpStatusCode Create(ProductPriceModel Thing);
		
        HttpStatusCode Create(ProductPriceModel Thing, List<int> dealerIds);

		HttpStatusCode Update(ProductPriceModel Thing);

		HttpStatusCode Update(ProductPriceModel Thing, List<int> dealerIds);

		HttpStatusCode Delete(int id);

        HttpStatusCode CreateRange(IEnumerable<ProductPriceModel> Thing);

        HttpStatusCode UpdateRange(IEnumerable<ProductPriceModel> Thing);

        HttpStatusCode DeleteRange(IEnumerable<int> id);

        ProductPriceModel GetById(int id);

        IEnumerable<ProductPriceModel> GetAll();

        int ExecuteRawSql(string command);
    }
}