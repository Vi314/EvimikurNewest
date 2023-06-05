using Entity.Entity;
using System.Net;

namespace Logic.Abstract_Repository
{
    public interface IProductRepository
    {
        HttpStatusCode Create(ProductModel product);

        HttpStatusCode Update(ProductModel product);

        HttpStatusCode Delete(int id);

        HttpStatusCode CreateRange(IEnumerable<ProductModel> Thing);

        HttpStatusCode UpdateRange(IEnumerable<ProductModel> Thing);

        HttpStatusCode DeleteRange(IEnumerable<int> id);

        ProductModel GetById(int id);

        IEnumerable<ProductModel> GetAll();

        int ExecuteRawSql(string command);
    }
}