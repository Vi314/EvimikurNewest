using Entity.Entity;

namespace Logic.Abstract_Service
{
    public interface ICategoryService
    {
        string CreateOne(Category category);
        string UpdateOne(Category category);
        string DeleteCategory(int id);
        IEnumerable<Category> GetCategories();
        Category GetById(int id);


}
}