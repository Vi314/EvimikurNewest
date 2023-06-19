using Entity.Base;
using Humanizer;
using Logic;
using Logic.Abstract_Generic;
using Microsoft.AspNetCore.Mvc;
using MVC.Areas.Entities.Models.BaseModels;
using MVC.Areas.Entities.Models.MapperAbstractGeneric;
using System.Reflection;
using Z.EntityFramework.Extensions;

namespace MVC.Areas.Entities.BaseControllers
{
    public class EntityConnectionController<Model, Service, Dto, Mapper> : BaseDashboardController<Model, Service, Dto, Mapper>
                   where Model : BaseModel
                   where Service : IBaseService<Model>
                   where Dto : BaseDto
                   where Mapper : IBaseMapper<Dto, Model>
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly Service _service;
        private readonly Mapper _mapper;

        public EntityConnectionController(Service service, Mapper mapper, IServiceProvider serviceProvider) : base(service, mapper)
        {
            _serviceProvider = serviceProvider;
            _service = service;
            _mapper = mapper;
        }

        //TODO Make sense of the reflection method you have that gets the properties of the Dto 

        /// <summary>
        /// This property decides on which models will have an associated "ConnectionManager" class called after creation 
        /// </summary>
        public List<BaseModel> ConnectionModels { get; set; }

        public List<string> ListNames { get; set; }

        public void Test()
        {
            var typeOfDto = typeof(Dto);
            var foreignKeys = new List<PropertyInfo>();

            foreach (string name in ListNames)
            {
                if (name is not null)
                    foreignKeys.Add(typeOfDto.GetProperty(name));
            }

        }

        public virtual IEntityConnectionManager<EntityType> InjectConnectionManager<EntityType>()
        {
            var connectionManager = _serviceProvider.GetService<IEntityConnectionManager<EntityType>>();
            return connectionManager;
        }

        [HttpPost]
        public IActionResult Create(Dto dto)
        {
            return base.Create();
        }

        public override IActionResult Update(Dto dto)
        {
            
            return base.Update(dto);    
        }
    }
}
