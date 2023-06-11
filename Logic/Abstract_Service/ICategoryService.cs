using Entity.Entity;
using System.Net;

namespace Logic.Abstract_Service
{
    public interface ICategoryService
    {
        HttpStatusCode CreateRange(IEnumerable<CategoryModel> Thing);

        HttpStatusCode UpdateRange(IEnumerable<CategoryModel> Thing);

        HttpStatusCode DeleteRange(IEnumerable<int> id);

        HttpStatusCode CreateOne(CategoryModel category);

        HttpStatusCode UpdateOne(CategoryModel category);

        HttpStatusCode DeleteCategory(int id);

        IEnumerable<CategoryModel> GetCategories();

        CategoryModel GetById(int id);
    }
}