using Entity.Base;
using Humanizer;
using Logic.Abstract_Generic;
using Microsoft.AspNetCore.Mvc;
using MVC.Areas.Entities.Models.BaseModels;
using MVC.Areas.Entities.Models.MapperAbstractGeneric;

namespace MVC.Areas.Entities.BaseControllers
{
    public class EntityConnectionController<Model, Service, Dto, Mapper> : BaseDashboardController<Model, Service, Dto, Mapper>
                   where Model : BaseEntity
                   where Service : IBaseService<Model>
                   where Dto : BaseDto
                   where Mapper : IBaseMapper<Dto, Model>
    {
        public EntityConnectionController(Service service, Mapper mapper) : base(service, mapper)
        {

        }



        public IActionResult Index()
        {
            return View();
        }
    }
}
