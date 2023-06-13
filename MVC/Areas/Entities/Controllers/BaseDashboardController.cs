using Entity.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MVC.Areas.Entities.Models.ViewModels;

namespace MVC.Areas.Entities.Controllers
{
    [Authorize(Roles ="Admin")]
    public class BaseDashboardController<TDto, XModel> : Controller where TDto : BaseDTO where XModel : BaseEntity
    {
        [AllowAnonymous]
        public virtual IActionResult Index()
        {
            
            return View();
        }

        public virtual IActionResult Create()
        {

            return View();
        }

        public virtual IActionResult Update()
        {
            return View();
        }

        public virtual IActionResult Delete()
        {
            return View();
        }

    }
}
