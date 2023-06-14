using Entity.Entity;
using Logic.Abstract_Service;
using Microsoft.AspNetCore.Mvc;
using MVC.Areas.Entities.BaseControllers;
using MVC.Areas.Entities.Models.MapperAbstract;
using MVC.Areas.Entities.Models.ViewModels;

namespace MVC.Areas.Entities.Controllers
{
    [Area("Entities")]
    public class DealerController : BaseDashboardController<DealerModel, IDealerService, DealerDto, IDealerMapper>
    {
        private readonly IDealerService _service;
        private readonly IDealerMapper _mapper;

        public DealerController(IDealerService service, IDealerMapper mapper) : base(service, mapper)
        {
            _service = service;
            _mapper = mapper;
        }
        
    }
}