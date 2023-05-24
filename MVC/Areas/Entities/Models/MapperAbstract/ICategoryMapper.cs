using Entity.Entity;
using MVC.Areas.Entities.Models.ViewModels;

namespace MVC.Areas.Entities.Models.MapperAbstract
{
	public interface ICategoryMapper
	{
		public Category FromDto(CategoryDTO categoryDTO);
		public CategoryDTO FromEntity(Category category);
		public IEnumerable<CategoryDTO> FromEntityRange(IEnumerable<Category> entities); 
        public IEnumerable<Category> FromDtoRange(IEnumerable<CategoryDTO> entities); 

    }
}
