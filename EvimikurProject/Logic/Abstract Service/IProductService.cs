using Entity.Entity;

namespace Logic.Abstract_Service
{
    public interface IProductService
    {
        string CreateProduct(Product product);
        string UpdateProduct(Product product);
        string DeleteProduct(int id);
        IEnumerable<Product> GetProducts();
        Product GetById(int id);

}
}