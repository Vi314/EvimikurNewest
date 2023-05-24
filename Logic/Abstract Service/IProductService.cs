using Entity.Entity;
using System.Net;

namespace Logic.Abstract_Service
{
    public interface IProductService
    {
		HttpStatusCode CreateRange(IEnumerable<Product> Thing);
		HttpStatusCode UpdateRange(IEnumerable<Product> Thing);
		HttpStatusCode DeleteRange(IEnumerable<int> id);

		HttpStatusCode CreateOne(Product product);
        HttpStatusCode UpdateOne(Product product);
        HttpStatusCode DeleteProduct(int id);
        IEnumerable<Product> GetProducts();
        Product GetById(int id);

}
}