using Entity.Entity;
using System.Net;

namespace Logic.Abstract_Service
{
    public interface IProductService
    {
		HttpStatusCode CreateRange(IEnumerable<ProductModel> Thing);
		HttpStatusCode UpdateRange(IEnumerable<ProductModel> Thing);
		HttpStatusCode DeleteRange(IEnumerable<int> id);

		HttpStatusCode CreateOne(ProductModel product);
        HttpStatusCode UpdateOne(ProductModel product);
        HttpStatusCode DeleteProduct(int id);
        IEnumerable<ProductModel> GetProducts();
        ProductModel GetById(int id);

}
}