using Entity.Entity;
using System.Net;

namespace Logic.Abstract_Service
{
    public interface ICategoryService
	{
		HttpStatusCode CreateRange(IEnumerable<Category> Thing);
		HttpStatusCode UpdateRange(IEnumerable<Category> Thing);
		HttpStatusCode DeleteRange(IEnumerable<int> id);

		HttpStatusCode CreateOne(Category category);
        HttpStatusCode UpdateOne(Category category);
        HttpStatusCode DeleteCategory(int id);
		IEnumerable<Category> GetCategories();
        Category GetById(int id);


}
}