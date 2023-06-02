using Entity.Entity;
using MVC.Areas.Entities.Models.MapperAbstract;
using MVC.Areas.Entities.Models.ViewModels;

namespace MVC.Areas.Entities.Models.MapperConcrete
{
    public class CategoryMapper : ICategoryMapper
	{
        public CategoryModel FromDto(CategoryDTO categoryDTO)
        {
            CategoryModel category = new CategoryModel
            {
                Id = categoryDTO.Id,
                Name = categoryDTO.Name.Trim(),
                Description = categoryDTO.Description == null ? "" : categoryDTO.Description.Trim(),
            };
            return category;
        }
        public CategoryDTO FromEntity(CategoryModel category)
        {
            CategoryDTO categoryDTO = new CategoryDTO
            {
                Id = category.Id,
                Name = category.Name,
                Description = category.Description,
            };
            return categoryDTO;
        }
        public IEnumerable<CategoryModel> FromDtoRange(IEnumerable<CategoryDTO> entities)
        {
            throw new NotImplementedException();
        }



        public IEnumerable<CategoryDTO> FromEntityRange(IEnumerable<CategoryModel> entities)
        {
            throw new NotImplementedException();
        }

	}
}
