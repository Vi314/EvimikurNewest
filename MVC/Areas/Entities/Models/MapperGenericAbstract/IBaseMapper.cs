using Entity.Base;
using Entity.Entity;
using MVC.Areas.Entities.Models.ViewModels;

namespace MVC.Areas.Entities.Models.MapperAbstractGeneric
{
    public interface IBaseMapper<Dto, Model> 
        where Dto : BaseDto 
        where Model : BaseEntity
    {
        public Model FromDto(Dto dto);

        public Dto FromEntity(Model entity);

        public IEnumerable<Dto> FromEntityRange(IEnumerable<Model> entities);

        public IEnumerable<Model> FromDtoRange(IEnumerable<Dto> dtos);
    }
}
