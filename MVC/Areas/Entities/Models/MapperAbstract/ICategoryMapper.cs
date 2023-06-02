using Entity.Entity;
using MVC.Areas.Entities.Models.ViewModels;

namespace MVC.Areas.Entities.Models.MapperAbstract
{
	public interface ICategoryMapper
	{
		public CategoryModel FromDto(CategoryDTO categoryDTO);
		public CategoryDTO FromEntity(CategoryModel category);
		public IEnumerable<CategoryDTO> FromEntityRange(IEnumerable<CategoryModel> entities); 
        public IEnumerable<CategoryModel> FromDtoRange(IEnumerable<CategoryDTO> entities); 

    }
}
