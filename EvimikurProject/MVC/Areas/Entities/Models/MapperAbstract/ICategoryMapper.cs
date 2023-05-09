using Entity.Entity;
using MVC.Areas.Entities.Models.ViewModels;

namespace MVC.Areas.Entities.Models.MapperAbstract
{
	public interface ICategoryMapper
	{
		public Category ToCategory(CategoryDTO categoryDTO);
		public CategoryDTO FromCategory(Category category);
		//? public IEnumerable<CategoryDTO> FromCategoryList(IEnumerable<Category> categories); COULD BE IMPLEMENTED LATER AS AN IMPROVEMENT
	}
}
