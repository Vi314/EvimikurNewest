using Entity.Entity;
using MVC.Areas.Entities.Models.MapperAbstract;
using MVC.Areas.Entities.Models.MapperAbstractGeneric;
using MVC.Areas.Entities.Models.ViewModels;

namespace MVC.Areas.Entities.Models.MapperConcrete
{
    public class CategoryMapper : ICategoryMapper
    {
        public CategoryModel FromDto(CategoryDto categoryDTO)
        {
            CategoryModel category = new CategoryModel
            {
                Id = categoryDTO.Id,
                Name = categoryDTO.Name.Trim(),
                Description = categoryDTO.Description == null ? "" : categoryDTO.Description.Trim(),
            };
            return category;
        }

        public IEnumerable<CategoryModel> FromDtoRange(IEnumerable<CategoryDto> dtos)
        {
            foreach (var dto in dtos) 
            {
                yield return FromDto(dto);
            }
        }

        public CategoryDto FromEntity(CategoryModel category)
        {
            CategoryDto categoryDTO = new CategoryDto
            {
                Id = category.Id,
                Name = category.Name,
                Description = category.Description,
            };
            return categoryDTO;
        }

        public IEnumerable<CategoryDto> FromEntityRange(IEnumerable<CategoryModel> entities)
        {
            foreach (var entity in entities)
            {
                yield return FromEntity(entity);
            }
        }
    }
}