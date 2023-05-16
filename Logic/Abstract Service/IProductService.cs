using Entity.Entity;

namespace Logic.Abstract_Service
{
    public interface IProductService
    {
        string CreateOne(Product product);
        string UpdateOne(Product product);
        string DeleteProduct(int id);
        IEnumerable<Product> GetProducts();
        Product GetById(int id);

}
}