using Entity.Entity;
using System.Net;

namespace Logic.Abstract_Repository
{
    public interface ICategoryRepository
    {
        HttpStatusCode Create(CategoryModel category);

        HttpStatusCode Update(CategoryModel category);

        HttpStatusCode Delete(int id);

        HttpStatusCode CreateRange(IEnumerable<CategoryModel> Thing);

        HttpStatusCode UpdateRange(IEnumerable<CategoryModel> Thing);

        HttpStatusCode DeleteRange(IEnumerable<int> id);

        CategoryModel GetById(int id);

        IEnumerable<CategoryModel> GetAll();

        int ExecuteRawSql(string command);
    }
}