using Entity.Entity;

namespace Logic.Abstract_Service
{
    public interface ICategoryService
    {
        string CreateCategory(Category category);
        string UpdateCategory(Category category);
        string DeleteCategory(int id);
        IEnumerable<Category> GetCategories();
        Category GetById(int id);


}
}