using Entity.Entity;
using MVC.Areas.Entities.Models.MapperAbstract;
using MVC.Areas.Entities.Models.ViewModels;

namespace MVC.Areas.Entities.Models.MapperConcrete
{
    public class CategoryMapper : ICategoryMapper
	{
		public CategoryDTO FromCategory(Category category)
		{
			CategoryDTO categoryDTO= new CategoryDTO 
			{ 
				Id = category.Id,
				Name= category.Name,
				Description= category.Description,
			};
			return categoryDTO;
		}

        public Category FromDto(CategoryDTO categoryDTO)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Category> FromDtoRange(IEnumerable<CategoryDTO> entities)
        {
            throw new NotImplementedException();
        }

        public CategoryDTO FromEntity(Category category)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CategoryDTO> FromEntityRange(IEnumerable<Category> entities)
        {
            throw new NotImplementedException();
        }

        public Category ToCategory(CategoryDTO categoryDTO)
		{
			Category category = new Category 
			{
				Id = categoryDTO.Id,
				Name = categoryDTO.Name,
				Description = categoryDTO.Description,
			};
			return category;
		}

	}
}
